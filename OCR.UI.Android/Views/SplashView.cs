using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace OCR.UI.Android.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class SplashView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SplashView);
        }
    }
}
