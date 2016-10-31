using System;
using System.Threading.Tasks;
using OCR.Core.Dao;
using OCR.Core.Helpers;
using OCR.Core.Models;
using OCR.Core.ServiceContracts;

namespace OCR.Core.ViewModels
{
    public class SplashViewModel : BaseViewModel
    {
        private readonly IRepository<DeviceLocationModel> _repository;
        private readonly INetworkingService _networkingService;
        private readonly Timer _timer;

        private string _imageBase64;
        
        public SplashViewModel(
            IRepository<DeviceLocationModel> repository,
            INetworkingService networkingService,
            ILoggerService loggerService,
            IPreferenceService preferenceService,
            IUserInteractionService userInteractionService) : base(loggerService, preferenceService, userInteractionService)
        {
            _repository = repository;
            _networkingService = networkingService;

            _timer = new Timer(TimeSpan.FromSeconds(6), CheckRepositoryIsInitializedAndNavigateToNextViewModel).Start();
        }

        private void CheckRepositoryIsInitializedAndNavigateToNextViewModel()
        {
            if (_repository.IsInitialized)
            {
                CanNavigateToNextViewModel = true;
                _timer.Stop();

                GoToNextViewModel();
            }
        }

        private void GoToNextViewModel()
        {
            ShowFirstViewModel();
        }

        public override async void Start()
        {
            base.Start();

            await GetSplashImageAsync();
        }

        private async Task GetSplashImageAsync()
        {
            try
            {
                if (!_networkingService.IsInternetConnected)
                {
                    HideSpinnerAndSetStatusMessage("No internet connection");
                    return;
                }

                // TODO: cache the image
            }
            catch (Exception ex)
            {
                LogExceptionHideSpinnerAndSetStatusMessage(ex);
                return;
            }
        }

        public string ImageBase64
        {
            get { return _imageBase64; }
            private set
            {
                _imageBase64 = value;
                RaisePropertyChanged(() => ImageBase64);
            }
        }

        public override string ViewName
        {
            get { return "Get Splash"; }
        }
    }
}