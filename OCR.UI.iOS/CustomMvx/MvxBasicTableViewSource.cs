using System;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace OCR.UI.iOS.CustomMvx
{
    public class MvxBasicTableViewSource<T> : MvxSimpleTableViewSource where T : MvxTableViewCell
    {
        public MvxBasicTableViewSource(IntPtr handle) : base(handle)
        {
        }

        public MvxBasicTableViewSource(UITableView tableView, string nibName, string cellIdentifier = null, NSBundle bundle = null) : base(tableView, nibName, cellIdentifier, bundle)
        {
        }

        public MvxBasicTableViewSource(UITableView tableView, Type cellType, string cellIdentifier = null) : base(tableView, cellType, cellIdentifier)
        {
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            var tourListTableViewCell = tableView.DequeueReusableCell(CellIdentifier) as T ??
                                        CreateRow();

            return tourListTableViewCell.Bounds.Height;
        }

        private T CreateRow()
        {
            const string methodToCreateRow = "Create";

            var methodInfo = typeof (T).GetMethod(methodToCreateRow);

            if (methodInfo != null)
            {
                var createdRow = methodInfo.Invoke(null, null); //null - means calling static method

                var typedRow = createdRow as T;

                if (typedRow != null)
                {
                    {
                        return typedRow;
                    }
                }
            }

            throw new Exception($"Can't create row. {typeof(T)} doesn't have a method called {methodToCreateRow}");
        }
    }
}