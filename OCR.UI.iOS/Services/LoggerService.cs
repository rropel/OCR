using System;
using HockeyApp.iOS;
using OCR.Core.ServiceContracts;

namespace OCR.UI.iOS.Services
{
    public class LoggerService : ILoggerService
    {
        public void LogException(Exception ex)
        {
            var eventName = $"Exception {ex}";

            LogEvent(eventName);
        }

        public void LogEvent(string eventName)
        {
            var manager = BITHockeyManager.SharedHockeyManager;
            manager.MetricsManager.TrackEvent(eventName);
        }
    }
}