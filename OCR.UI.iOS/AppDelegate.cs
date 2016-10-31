using Foundation;
using HockeyApp.iOS;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform;
using UIKit;

namespace OCR.UI.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate
    {
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            SetupMVVMCross();
            
            SetupHockeyApp();

            Window.MakeKeyAndVisible();

            return true;
        }
        private void SetupMVVMCross()
        {
            var setup = new Setup(this, Window);
            setup.Initialize();

            var startup = Mvx.Resolve<IMvxAppStart>();
            startup.Start();
        }

        private static void SetupHockeyApp()
        {
            //var manager = BITHockeyManager.SharedHockeyManager;
            //manager.Configure("f0c2129441be46baa06c15af74c159a8");
            //manager.CrashManager.CrashManagerStatus = BITCrashManagerStatus.AutoSend;
            //manager.StartManager();
        }
    }
}