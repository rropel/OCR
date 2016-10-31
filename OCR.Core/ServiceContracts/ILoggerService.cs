using System;

namespace OCR.Core.ServiceContracts
{
    public interface ILoggerService
    {
        void LogException(Exception ex);
        void LogEvent(string eventName);
    }
}