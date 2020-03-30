using UIKit;
using WeatherApp.iOS.Views;

namespace WeatherApp.iOS.Utility
{
    /// <summary>
    /// Coordinates transition between view controllers, by inserting custom edge recognizer and synchronizing it with the custom pop animation.
    /// </summary>
    public class CustomTransitionCoordinator : UINavigationControllerDelegate
    {
        UIPercentDrivenInteractiveTransition interactor = null;

        public override IUIViewControllerAnimatedTransitioning GetAnimationControllerForOperation(
            UINavigationController navigationController, UINavigationControllerOperation operation, UIViewController fromViewController, UIViewController toViewController)
        {
            //TODO: remove dependency on CitySelectViewController with interface or something else
            if (operation == UINavigationControllerOperation.Push && fromViewController is HomePageController vc1)
            {
                //Recognizer is added only on push so that user can interactively pop the presented screen.
                var recognizer = new UIScreenEdgePanGestureRecognizer();
                recognizer.Edges = UIRectEdge.Left;
                recognizer.AddTarget(() =>
                {
                    HandleRecognizer(recognizer, navigationController);
                });
                toViewController.View.AddGestureRecognizer(recognizer);
                return new CustomTransition(operation, vc1.AnimationSourceView);
            }
            else if (operation == UINavigationControllerOperation.Pop && toViewController is HomePageController vc2)
            {
                return new CustomTransition(operation, vc2.AnimationSourceView);
            }

            return null;
        }

        //https://stackoverflow.com/a/26569703/1981314
        void HandleRecognizer(UIScreenEdgePanGestureRecognizer recognizer, UINavigationController navigationController)
        {
            var translate = recognizer.TranslationInView(recognizer.View);
            var percent = translate.X / recognizer.View.Bounds.Width * 2;
            var velocity = recognizer.VelocityInView(recognizer.View);

            if (percent > 1) percent = 1;

            if (recognizer.State == UIGestureRecognizerState.Began)
            {
                interactor = new UIPercentDrivenInteractiveTransition();
                navigationController.PopViewController(true);
            }

            else if (recognizer.State == UIGestureRecognizerState.Changed)
            {
                interactor.UpdateInteractiveTransition(percent);
            }

            else if (recognizer.State == UIGestureRecognizerState.Ended)
            {

                if (percent > 0.5 || velocity.X > 0)
                {
                    interactor.FinishInteractiveTransition();
                }
                else
                {
                    interactor.CancelInteractiveTransition();
                }
                interactor = null;
            }
        }

        public override IUIViewControllerInteractiveTransitioning GetInteractionControllerForAnimationController(
            UINavigationController navigationController, IUIViewControllerAnimatedTransitioning animationController)
        {
            return interactor;
        }
    }
}
