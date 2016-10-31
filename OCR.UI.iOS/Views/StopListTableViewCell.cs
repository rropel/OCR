using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using OCR.Core.DTOs;
using OCR.UI.iOS.Converters;
using UIKit;

namespace OCR.UI.iOS.Views
{
    public partial class StopListTableViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString(nameof(StopListTableViewCell));
        public static readonly UINib Nib = UINib.FromName(nameof(StopListTableViewCell), NSBundle.MainBundle);

        public StopListTableViewCell(IntPtr handle) : base(handle)
        {
            InitializeBindings();
        }

        public static MvxTableViewCell Create()
        {
            return (StopListTableViewCell)StopListTableViewCell.Nib.Instantiate(null, null)[0];
        }

        private void InitializeBindings()
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<StopListTableViewCell, StopDTO>();
                set.Bind(labelSite).To(vm => vm.SiteName);
                set.Apply();
            });
        }
    }
}