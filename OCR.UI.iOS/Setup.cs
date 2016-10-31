using System;
using System.IO;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using OCR.Core;
using OCR.Core.ServiceContracts;
using OCR.UI.iOS.CustomMvx;
using OCR.UI.iOS.Helpers;
using OCR.UI.iOS.Services;
using Plugin.Geolocator;
using UIKit;
using Version.Plugin;
using Version.Plugin.Abstractions;

namespace OCR.UI.iOS
{
    public class Setup : MvxIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        public Setup(MvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter)
            : base(applicationDelegate, presenter)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            InitializeContainers();

            SetupConfiguration();

            return new App();
        }

        private void SetupConfiguration()
        {
            var preferenceService = Mvx.Resolve<IPreferenceService>();

            // we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
            // (they don't want non-user-generated data in Documents)
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            preferenceService.DbPath = Path.Combine(documentsPath, "../Library/");

            preferenceService.SQLitePlatform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
        }

        private void InitializeContainers()
        {
            Mvx.LazyConstructAndRegisterSingleton<IPreferenceService, PreferenceService>();
            Mvx.LazyConstructAndRegisterSingleton<INetworkingService, NetworkingService>();
            Mvx.LazyConstructAndRegisterSingleton<ILoggerService, LoggerService>();

            Mvx.RegisterSingleton(CrossGeolocator.Current);

            Mvx.RegisterType<IDeviceService, DeviceService>();
            Mvx.RegisterType<IUserInteractionService, UserInteractionService>();

            Mvx.RegisterType<IVersion, VersionImplementation>();
        }
        
        protected override IMvxTrace CreateDebugTrace()
		{
			return new MyDebugTrace();
		}

        protected override IMvxIosViewPresenter CreatePresenter()
        {
            return new CustomViewPresenter(ApplicationDelegate, Window);
            //return new MvxSidebarPresenter((MvxApplicationDelegate)ApplicationDelegate, Window);
        }
    }
}