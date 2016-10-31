using OCR.Core.ServiceContracts;
using UIKit;

namespace OCR.UI.iOS.Services
{
    public class DeviceService : IDeviceService
    {
        public string GetDeviceId()
        {
           var device = UIDevice.CurrentDevice;

            return device.IdentifierForVendor.AsString();
        }

        public int GetCurrentBatteryLevel()
        {
            return 100;
        }

        public int GetBatteryStatus()
        {
            return 1;
        }
    }
}