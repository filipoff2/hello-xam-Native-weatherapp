//based on the file DialogService.cs

using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using GalaSoft.MvvmLight.Views;
using Plugin.CurrentActivity;

namespace WeatherApp.Droid.Navigation
{
    
    public class DialogServiceDroid : IDialogService
    {
        public Task ShowError(string message, string title, string buttonText, Action afterHideCallback)
        {
            Action<bool> callback = r =>
            {
                if (afterHideCallback != null)
                {
                    afterHideCallback();
                    afterHideCallback = null;
                }
            };

            var info = CreateDialog(
                message,
                title,
                buttonText,
                null,
                callback);

            info.Dialog.Show();
            return info.Tcs.Task;
        }

        public Task ShowError(Exception error, string title, string buttonText, Action afterHideCallback)
        {
            Action<bool> callback = r =>
            {
                if (afterHideCallback != null)
                {
                    afterHideCallback();
                    afterHideCallback = null;
                }
            };

            var info = CreateDialog(
                error.Message,
                title,
                buttonText,
                null,
                callback);

            info.Dialog.Show();
            return info.Tcs.Task;
        }
     
        public Task ShowMessage(string message, string title)
        {
            var info = CreateDialog(
                message,
                title);

            info.Dialog.Show();
            return info.Tcs.Task;
        }

        public Task ShowMessage(string message, string title, string buttonText, Action afterHideCallback)
        {
            Action<bool> callback = r =>
            {
                if (afterHideCallback != null)
                {
                    afterHideCallback();
                    afterHideCallback = null;
                }
            };

            var info = CreateDialog(
                message,
                title,
                buttonText,
                null,
                callback);

            info.Dialog.Show();
            return info.Tcs.Task;
        }
        
        public Task<bool> ShowMessage(string message, string title, string buttonConfirmText, string buttonCancelText,
            Action<bool> afterHideCallback)
        {
            Action<bool> callback = r =>
            {
                if (afterHideCallback != null)
                {
                    afterHideCallback(r);
                    afterHideCallback = null;
                }
            };

            var info = CreateDialog(
                message,
                title,
                buttonConfirmText,
                buttonCancelText ?? "Cancel",
                callback);

            info.Dialog.Show();
            return info.Tcs.Task;
        }

        public Task ShowMessageBox(string message, string title)
        {
            return ShowMessage(message, title);
        }
        private static AlertDialogInfo CreateDialog(
               string content,
               string title,
               string okText = null,
               string cancelText = null,
               Action<bool> afterHideCallbackWithResponse = null)
        {
            var tcs = new TaskCompletionSource<bool>();

            var builder = new AlertDialog.Builder(CrossCurrentActivity.Current.Activity);

            builder.SetMessage(content);
            builder.SetTitle(title);

            AlertDialog dialog = null;

            builder.SetPositiveButton(
                okText ?? "OK",
                (d, index) =>
                {
                    tcs.TrySetResult(true);

                    // ReSharper disable AccessToModifiedClosure
                    if (dialog != null)
                    {
                        dialog.Dismiss();
                        dialog.Dispose();
                    }

                    if (afterHideCallbackWithResponse != null)
                    {
                        afterHideCallbackWithResponse(true);
                    }
                    // ReSharper restore AccessToModifiedClosure
                });

            if (cancelText != null)
            {
                builder.SetNegativeButton(
                    cancelText,
                    (d, index) =>
                    {
                        tcs.TrySetResult(false);

                        // ReSharper disable AccessToModifiedClosure
                        if (dialog != null)
                        {
                            dialog.Dismiss();
                            dialog.Dispose();
                        }

                        if (afterHideCallbackWithResponse != null)
                        {
                            afterHideCallbackWithResponse(false);
                        }
                        // ReSharper restore AccessToModifiedClosure
                    });
            }

            builder.SetOnDismissListener(
                new OnDismissListener(
                    () =>
                    {
                        tcs.TrySetResult(false);

                        if (afterHideCallbackWithResponse != null)
                        {
                            afterHideCallbackWithResponse(false);
                        }
                    }));

            dialog = builder.Create();

            return new AlertDialogInfo
            {
                Dialog = dialog,
                Tcs = tcs
            };
        }

        private struct AlertDialogInfo
        {
            public AlertDialog Dialog;
            public TaskCompletionSource<bool> Tcs;
        }

        private sealed class OnDismissListener : Java.Lang.Object, IDialogInterfaceOnDismissListener
        {
            private readonly Action _action;

            public OnDismissListener(Action action)
            {
                _action = action;
            }

            public void OnDismiss(IDialogInterface dialog)
            {
                _action();
            }
        }
    }
}