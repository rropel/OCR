using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using OCR.Core.Helpers;
using OCR.Core.ServiceContracts;

namespace OCR.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        private bool _canNavigateToNextViewModel;

        protected ILoggerService LoggerService { get; set; }
        protected IPreferenceService PreferenceService { get; set; }
        public IUserInteractionService UserInteractionService { get; set; }
        public abstract string ViewName { get; }

        protected BaseViewModel(ILoggerService loggerService, IPreferenceService preferenceService, IUserInteractionService userInteractionService)
        {
            LoggerService = loggerService;
            PreferenceService = preferenceService;
            UserInteractionService = userInteractionService;
        }

        protected void ShowFirstViewModel()
        {
            ShowViewModelAndMakeItTheFirstOne<StopListViewModel>();
        }

        protected void ClearStackAndShowViewModel<TViewModel>() where TViewModel : BaseViewModel
        {
            var presentationBundle = new MvxBundle(new Dictionary<string, string> { { PresentationBundleFlagKeys.CLEAR_STACK, "" } });

            ShowViewModel<TViewModel>(presentationBundle: presentationBundle);
        }

        protected void ShowViewModelBackOrInPlace<TViewModel>() where TViewModel : BaseViewModel
        {
            var presentationBundle = new MvxBundle(new Dictionary<string, string> { { PresentationBundleFlagKeys.BACK_OR_IN_PLACE, "" } });

            ShowViewModel<TViewModel>(presentationBundle: presentationBundle);
        }

        protected void ShowViewModelAndMakeItTheFirstOne<TViewModel>() where TViewModel : BaseViewModel
        {
            var presentationBundle = new MvxBundle(new Dictionary<string, string> { { PresentationBundleFlagKeys.MAKE_IT_THE_FIRST_ONE, "" } });

            ShowViewModel<TViewModel>(presentationBundle: presentationBundle);
        }

        public bool CanNavigateToNextViewModel
        {
            get { return _canNavigateToNextViewModel; }
            protected set
            {
                _canNavigateToNextViewModel = value;
                RaisePropertyChanged(() => CanNavigateToNextViewModel);
            }
        }

        protected void LogMessageHideSpinnerAndSetStatusMessage(string message)
        {
            LoggerService.LogEvent(message);
            HideSpinnerAndSetStatusMessage(message);
        }

        protected void HideSpinnerAndSetStatusMessage(string message)
        {
            UserInteractionService.HideSpinner();
        }

        protected void LogExceptionHideSpinnerAndSetStatusMessage(Exception ex)
        {
            LoggerService.LogException(ex);
            HideSpinnerAndSetStatusMessage(ex.Message);
        }

        protected void HideSpinnerAndRedirectToViewModel<T>(bool makeItFirst) where T : BaseViewModel
        {
            UserInteractionService.HideSpinner();
            if (makeItFirst)
            {
                ShowViewModelAndMakeItTheFirstOne<T>();
            }
            else
            {
                ShowViewModel<T>();
            }
        }
    }
}