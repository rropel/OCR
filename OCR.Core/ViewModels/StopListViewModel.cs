using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using OCR.Core.DTOs;
using OCR.Core.Enums;
using OCR.Core.ServiceContracts;

namespace OCR.Core.ViewModels
{
    public class StopListViewModel : BaseBasicTableListViewModelBase<StopDTO>
    {
        public StopListViewModel(
            ILoggerService loggerService, 
            IPreferenceService preferenceService,
            IUserInteractionService userInteractionService)
            : base(loggerService, preferenceService, userInteractionService)
        {
            
        }

        public override string ViewName => "Some name";
        protected override void DoSelectItem(StopDTO item)
        {
            throw new NotImplementedException();
        }

        protected override Task DoTopRightButtonCommandAsync()
        {
            throw new NotImplementedException();
        }

        protected override Task FillCollectionAsync()
        {
            throw new NotImplementedException();
        }
    }
}