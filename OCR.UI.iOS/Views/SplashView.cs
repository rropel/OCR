using MvvmCross.Binding.BindingContext;
using OCR.Core.ViewModels;
using OCR.UI.iOS.Converters;

namespace OCR.UI.iOS.Views
{
    public partial class SplashView : BaseMvxViewController<SplashViewModel>
    {
        public SplashView() : base(nameof(SplashView), null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var bindings = this.CreateBindingSet<SplashView, SplashViewModel>();

            bindings.Bind(imageSplash)
                .For(v => v.Image)
                .To(vm => vm.ImageBase64)
                .OneWay()
                .WithConversion(new StringToImageConverter());

            // This 2 properties can be used for state management (may to show / hide some control)
            bindings.Bind(this).For(v => v.CanNavigateToNextViewModel).To(vm => vm.CanNavigateToNextViewModel);

            bindings.Apply();
        }

        public bool CanNavigateToNextViewModel { get; set; }
        public bool IsImageLoaded { get; set; }
    }
}