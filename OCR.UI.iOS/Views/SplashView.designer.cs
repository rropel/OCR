// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//

using System.CodeDom.Compiler;
using Foundation;

namespace OCR.UI.iOS.Views
{
    [Register ("SplashView")]
    partial class SplashView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imageSplash { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imageSplash != null) {
                imageSplash.Dispose ();
                imageSplash = null;
            }
        }
    }
}