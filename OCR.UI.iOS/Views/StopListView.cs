using MvvmCross.Binding.BindingContext;
using OCR.Core.ViewModels;
using OCR.UI.iOS.CustomMvx;
using UIKit;

namespace OCR.UI.iOS.Views
{
    public partial class StopListView : BaseMvxViewController<StopListViewModel>
    {
        private UIButton _starTourButton;

        public StopListView() : base(nameof(StopListView), null, true)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            AddButonToNavigationBar();

            InitializeBindings();
        }

        private void AddButonToNavigationBar()
        {
            _starTourButton = Helpers.ControlFactory.GetPlayButton();

            var navigationBarRightButton = new UIBarButtonItem(_starTourButton);

            this.NavigationItem.SetRightBarButtonItem(navigationBarRightButton, true);
        }

        private void InitializeBindings()
        {
            var bindings = this.CreateBindingSet<StopListView, StopListViewModel>();
            // Logging exception screen
            var source = new MvxBasicTableViewSource<StopListTableViewCell>(tableViewStopList, StopListTableViewCell.Key, StopListTableViewCell.Key);
            bindings.Bind(source).To(vm => vm.Collection);
            bindings.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.ItemSelectedCommand);

            bindings.Bind(_starTourButton).To(vm => vm.TopRightButtonAsyncCommand);

            tableViewStopList.Source = source;
            tableViewStopList.RowHeight = UITableView.AutomaticDimension;
            tableViewStopList.EstimatedRowHeight = 60f;
            tableViewStopList.ReloadData();

            bindings.Apply();
        }
    }
}