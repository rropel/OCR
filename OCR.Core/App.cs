using System.Threading;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using OCR.Core.Dao;
using OCR.Core.Models;
using OCR.Core.ViewModels;
using Task = System.Threading.Tasks.Task;

namespace OCR.Core
{
    public class App : MvxApplication
    {
        public App()
        {
        }

        public override async void Initialize()
        {
            InitializeContainers();

            SetInitialViewModel();

            await InitializeDataBaseAsync();
        }

        private void SetInitialViewModel()
        {
            RegisterAppStart<SplashViewModel>();
        }

        private void InitializeContainers()
        {
            Mvx.LazyConstructAndRegisterSingleton<IDatabase, Database>();

            Mvx.LazyConstructAndRegisterSingleton<IRepository<DeviceLocationModel>, Repository<DeviceLocationModel>>();
        }

        private async Task InitializeDataBaseAsync()
        {
            var cancellationTokenSource = new CancellationTokenSource();

            var context = Mvx.Resolve<IDatabase>();
            await context.InitializeSQLiteAsync(cancellationTokenSource.Token);
        }
    }
}
