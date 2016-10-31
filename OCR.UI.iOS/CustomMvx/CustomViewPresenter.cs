using System.Linq;
using CoreAnimation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using OCR.Core.Helpers;
using UIKit;

namespace OCR.UI.iOS.CustomMvx
{
    public class CustomViewPresenter : MvxIosViewPresenter
    {
        private IMvxIosViewCreator _viewCreator;

        public CustomViewPresenter(IUIApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {

        }

        private IMvxIosViewCreator GetViewCreator()
        {
            return _viewCreator ?? (_viewCreator = Mvx.Resolve<IMvxIosViewCreator>());
        }

        public override void Show(MvxViewModelRequest request)
        {
            if (request.PresentationValues != null)
            {
                var viewCreator = GetViewCreator();

                // More info at:
                // - http://gregshackles.com/presenters-in-mvvmcross-using-presentation-values/
                // - https://gist.github.com/gshackles/5735595
                if (request.PresentationValues.ContainsKey(PresentationBundleFlagKeys.CLEAR_STACK))
                {
                    var nextViewController = (UIViewController)viewCreator.CreateView(request);

                    if (MasterNavigationController.TopViewController.GetType() != nextViewController.GetType())
                    {
                        MasterNavigationController.PopToRootViewController(false);
                        MasterNavigationController.PushViewController(nextViewController, false);
                    }

                    return;
                }
                else if (request.PresentationValues.ContainsKey(PresentationBundleFlagKeys.MAKE_IT_THE_FIRST_ONE))
                {
                    MasterNavigationController.SetViewControllers(new UIViewController[] { }, false);
                }
                else if (request.PresentationValues.ContainsKey(PresentationBundleFlagKeys.BACK_OR_IN_PLACE))
                {
                    var nextViewController = (UIViewController)viewCreator.CreateView(request);
                    var existingViewController =
                        MasterNavigationController.ViewControllers.FirstOrDefault(
                            vc => vc.GetType() == nextViewController.GetType() && vc != CurrentTopViewController);

                    if (existingViewController != null)
                    {
                        MasterNavigationController.PopToViewController(existingViewController, true);
                    }
                    else
                    {
                        var transition = new CATransition
                        {
                            Duration = 0.3,
                            Type = CAAnimation.TransitionPush,
                            Subtype = CAAnimation.TransitionFade
                        };

                        MasterNavigationController.PopViewController(false);
                        MasterNavigationController.View.Layer.AddAnimation(transition, null);
                        MasterNavigationController.PushViewController(nextViewController, false);
                    }

                    return;
                }
            }

            base.Show(request);
        }
    }
}