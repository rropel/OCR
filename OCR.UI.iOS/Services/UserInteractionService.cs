using System;
using System.Threading.Tasks;
using BTProgressHUD;
using CRSAlertView.Source;
using OCR.Core.ServiceContracts;
using UIKit;

namespace OCR.UI.iOS.Services
{
    public class UserInteractionService : IUserInteractionService
    {
        private CRSAlertView.Source.CRSAlertView _alertView;
        private CRSAlertView.Source.CRSAlertView _confirmView;
        private const string CANCEL_TEXT = "Cancel";
        private const string ACCEPT_TEXT = "Accept";
        private Func<Task> _confirmPopUpAction = null;
        private Func<Task> _cancelPopUpAction = null;

        public void ShowSpinner()
        {
            if (!BTProgressHUD.BTProgressHUD.IsVisible)
            {
                BTProgressHUD.BTProgressHUD.Show(maskType: ProgressHUD.MaskType.Black);
            }
        }

        public void HideSpinner()
        {
            BTProgressHUD.BTProgressHUD.Dismiss();
        }

        public void DisplayErrorAlertPopUp(string message)
        {
            var alertPopUp = AlertPopUp;

            if (message.Length > 144)
            {
                message = $"{message.Substring(0, 144)}...";
            }

            alertPopUp.Title = "Error";
            alertPopUp.Message = message;
            alertPopUp.Show();
        }

        public void DisplayConfirmPopUp(string title, string message, Func<Task> confirmPopUpAction = null, Func<Task> cancelPopUpAction = null)
        {
            var confirmPopUp = ConfirmPopUp;

            if (message.Length > 144)
            {
                message = $"{message.Substring(0, 144)}...";
            }

            if (confirmPopUpAction != null)
            {
                _confirmPopUpAction = confirmPopUpAction;
            }

            if (cancelPopUpAction != null)
            {
                _cancelPopUpAction = cancelPopUpAction;
            }

            confirmPopUp.Title = title;
            confirmPopUp.Message = message;
            confirmPopUp.Show();
        }

        private async void ConfirmPopUpAction(CRSAlertView.Source.CRSAlertView view)
        {
            if (_confirmPopUpAction != null)
            {
                await _confirmPopUpAction.Invoke();
            }
        }

        private async void CancelPopUpAction(CRSAlertView.Source.CRSAlertView view)
        {
            if (_cancelPopUpAction != null)
            {
                await _cancelPopUpAction.Invoke();
            }
        }

        private CRSAlertView.Source.CRSAlertView AlertPopUp
        {
            get
            {
                if (_alertView != null)
                {
                    return _alertView;
                }

                var action = new CRSAlertAction
                {
                    Text = "Ok",
                    Highlighted = true,
                    TintColor = UIColor.Cyan,
                    //DidSelect = (alert) => {
                    //                           // Do something here on press
                    //}
                };

                _alertView = new CRSAlertView.Source.CRSAlertView
                {
                    //Title = "Hello World!",
                    //Message = "This alert actually works :)",
                    //Image = UIImage.FromBundle("someIcon"),
                    Actions = new CRSAlertAction[] { action }
                };

                return _alertView;
            }
        }

        private CRSAlertView.Source.CRSAlertView ConfirmPopUp
        {
            get
            {
                if (_confirmView != null)
                {
                    return _confirmView;
                }

                var actionAccept = new CRSAlertAction
                {
                    Text = ACCEPT_TEXT,
                    Highlighted = true,
                    TintColor = UIColor.Cyan,
                    DidSelect = ConfirmPopUpAction
                };

                var actionCancel = new CRSAlertAction
                {
                    Text = CANCEL_TEXT,
                    DidSelect = CancelPopUpAction
                };

                _confirmView = new CRSAlertView.Source.CRSAlertView
                {
                    Actions = new CRSAlertAction[] { actionCancel, actionAccept }
                };

                return _confirmView;
            }
        }
    }
}