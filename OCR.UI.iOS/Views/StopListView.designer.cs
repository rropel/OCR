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
    [Register ("StopListView")]
    partial class StopListView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tableViewStopList { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (tableViewStopList != null) {
                tableViewStopList.Dispose ();
                tableViewStopList = null;
            }
        }
    }
}