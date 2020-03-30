using System;
using CoreGraphics;
using UIKit;

namespace WeatherApp.iOS.Utility
{
    /// <summary>
    /// Executes navigation controller animation where next view appears / disappears from a frame fragment on the previous view.
    /// </summary>
    public class CustomTransition : UIViewControllerAnimatedTransitioning
    {
        UIView sourceView;
        UINavigationControllerOperation operation;

        public CustomTransition(UINavigationControllerOperation operation, UIView view)
        {
            this.operation = operation;
            sourceView = view;
        }

        public override void AnimateTransition(IUIViewControllerContextTransitioning transitionContext)
        {
            const float Inset = 20;

            var fromView = transitionContext.GetViewFor(UITransitionContext.FromViewKey);
            var toView = transitionContext.GetViewFor(UITransitionContext.ToViewKey);
            var container = transitionContext.ContainerView;

            var smallFrame = sourceView.ConvertRectToView(sourceView.Bounds, container);
            var bigFrame = toView.Frame.Inset(-Inset, -Inset);

            var coverView = new UIView(bigFrame);
            Theme.Default.StyleRoundBorder(coverView);
            coverView.BackgroundColor = UIColor.White;

            /// <summary>
            /// Snapshot is used to give effect of smoothly appearing view, with alpha and frame size.
            /// </summary>
            UIView SetSnapshot(UIView view)
            {
                var snapshot = view.SnapshotView(false) ?? view.SnapshotView(true);
                coverView.Add(snapshot);
                snapshot.Frame = coverView.Bounds.Inset(Inset, Inset);
                snapshot.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
                return snapshot;
            }

            void Animate(CGRect frame1, CGRect frame2, float alpha1, float alpha2, UIView innerView)
            {
                container.AddSubview(coverView);
                var snapshot = SetSnapshot(innerView);

                coverView.Frame = frame1;
                snapshot.Alpha = alpha1;

                UIView.Animate(TransitionDuration(transitionContext), ()=> 
                {
                    coverView.Frame = frame2;
                    snapshot.Alpha = alpha2;
                }, ()=>
                {
                    var finished = !transitionContext.TransitionWasCancelled;

                    if (!finished)
                    {
                        toView.RemoveFromSuperview();
                    } else {
                        container.BringSubviewToFront(toView);
                    }

                    coverView.RemoveFromSuperview();
                    transitionContext.CompleteTransition(finished);
                });
            }

            if (operation == UINavigationControllerOperation.Push)
            {
                container.InsertSubview(toView, 0);
                Animate(smallFrame, bigFrame, 0, 1, toView);
            }
            else 
            {
                container.AddSubview(toView);
                Animate(bigFrame, smallFrame, 1, 0, fromView);
            }
        }

        public override double TransitionDuration(IUIViewControllerContextTransitioning transitionContext)
        {
            return 0.5;
        }
    }
}
