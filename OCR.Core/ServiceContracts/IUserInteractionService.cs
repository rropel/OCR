using System;
using System.Threading.Tasks;

namespace OCR.Core.ServiceContracts
{
    public interface IUserInteractionService
    {
        void ShowSpinner();
        void HideSpinner();
        void DisplayErrorAlertPopUp(string message);
        void DisplayConfirmPopUp(string title, string message, Func<Task> confirmPopUpAction = null, Func<Task> cancelPopUpAction = null);
    }
}