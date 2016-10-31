namespace OCR.Core.ServiceContracts
{
    public interface IDeviceService
    {
        string GetDeviceId();
        int GetCurrentBatteryLevel();
        int GetBatteryStatus();
    }
}