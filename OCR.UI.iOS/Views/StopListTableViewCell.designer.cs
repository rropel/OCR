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
    [Register ("StopListTableViewCell")]
    partial class StopListTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView imageIcon { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel labelAddress { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel labelCustomer { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel labelETA { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel labelSite { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel labelSiteTitle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel labelStopOptional { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (imageIcon != null) {
                imageIcon.Dispose ();
                imageIcon = null;
            }

            if (labelAddress != null) {
                labelAddress.Dispose ();
                labelAddress = null;
            }

            if (labelCustomer != null) {
                labelCustomer.Dispose ();
                labelCustomer = null;
            }

            if (labelETA != null) {
                labelETA.Dispose ();
                labelETA = null;
            }

            if (labelSite != null) {
                labelSite.Dispose ();
                labelSite = null;
            }

            if (labelSiteTitle != null) {
                labelSiteTitle.Dispose ();
                labelSiteTitle = null;
            }

            if (labelStopOptional != null) {
                labelStopOptional.Dispose ();
                labelStopOptional = null;
            }
        }
    }
}