using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using OCR.Core.ServiceContracts;

namespace OCR.Core.ViewModels
{
    public abstract class BaseBasicTableListViewModelBase<T> : BaseViewModel
    {
        private ObservableCollection<T> _collection;
        private MvxAsyncCommand _topRightButtonAsyncCommand;
        private MvxCommand<T> _itemSelectedCommand;
        //private MvxCommand _topRightButtonCommand;

        protected BaseBasicTableListViewModelBase(ILoggerService loggerService, IPreferenceService preferenceService, IUserInteractionService userInteractionService) : base(loggerService, preferenceService, userInteractionService)
        {
        }

        //public IMvxCommand TopRightButtonCommand
        //{
        //    get
        //    {
        //        _topRightButtonCommand = _topRightButtonCommand ?? new MvxCommand(DoTopRightButtonCommand);
        //        return _topRightButtonCommand;
        //    }
        //}

        public IMvxAsyncCommand TopRightButtonAsyncCommand
        {
            get
            {
                _topRightButtonAsyncCommand = _topRightButtonAsyncCommand ?? new MvxAsyncCommand(DoTopRightButtonCommandAsync);
                return _topRightButtonAsyncCommand;
            }
        }

        public ObservableCollection<T> Collection
        {
            get { return _collection; }
            set
            {
                _collection = value;
                RaisePropertyChanged(() => Collection);
            }
        }

        public IMvxCommand ItemSelectedCommand
        {
            get
            {
                _itemSelectedCommand = _itemSelectedCommand ?? new MvxCommand<T>(DoSelectItem);
                return _itemSelectedCommand;
            }
        }

        protected abstract void DoSelectItem(T item);

        protected abstract Task DoTopRightButtonCommandAsync();

        //protected abstract void DoTopRightButtonCommand();

        public override async void Start()
        {
            base.Start();

            try
            {
                UserInteractionService.ShowSpinner();

                await FillCollectionAsync();

                UserInteractionService.HideSpinner();
            }
            catch (Exception ex)
            {
                LogExceptionHideSpinnerAndSetStatusMessage(ex);
            }
        }

        protected abstract Task FillCollectionAsync();
    }
}