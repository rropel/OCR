using System;
using System.Linq;
using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.Platform;
using OCR.Core.ViewModels;

namespace OCR.UI.iOS.Views
{
    public abstract class BaseMvxViewController<T> : MvxViewController<T> where T : MvxViewModel
    {
        private readonly bool _forceShowNavitagationBar;
        
        protected BaseMvxViewController(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
            }

        protected BaseMvxViewController(string nibName, NSBundle bundle, bool forceShowNavitagationBar) : this(nibName, bundle)
        {
            _forceShowNavitagationBar = forceShowNavitagationBar;
        }

        public override void ViewDidLoad()
        {
            try
            {
                base.ViewDidLoad();

                if (_forceShowNavitagationBar)
                {
                    NavigationController.SetNavigationBarHidden(false, false);
                }
                else if (NavigationController.ViewControllers.Count() == 1)
                {
                    NavigationController.SetNavigationBarHidden(true, false);
                }

                var baseViewModel = ViewModel as BaseViewModel;

                if (baseViewModel != null)
                {
                    NavigationItem.Title = baseViewModel.ViewName;
                }
            }
            catch (Exception x)
            {
                throw;
            }
        }
    }
}