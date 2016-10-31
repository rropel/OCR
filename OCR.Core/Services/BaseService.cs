using System;
using OCR.Core.DTOs;
using OCR.Core.Enums;
using OCR.Core.ServiceContracts;

namespace OCR.Core.Services
{
    public abstract class BaseService
    {
        protected readonly ILoggerService LoggerService;
        protected readonly INetworkingService NetworkingService;

        protected BaseService(
            ILoggerService loggerService, 
            INetworkingService networkingService)
        {
            LoggerService = loggerService;
            NetworkingService = networkingService;
        }

        protected bool IsDeviceOnline()
        {
            var isDeviceOnline = NetworkingService.IsInternetConnected;

            return isDeviceOnline;
        }

        protected virtual Response<T> FailedResponse<T>(T result, string message)
        {
            var response = new Response<T>
            {
                Message = message,
                Result = result,
                Status = ResponseStatus.Failed
            };

            return response;
        }

        protected virtual Response<T> SuccessResponse<T>(T result, string message = null)
        {
            var response = new Response<T>
            {
                Message = message,
                Result = result,
                Status = ResponseStatus.Success
            };

            return response;
        }

        protected virtual Response<string> LogExceptionAndReturnFailedResponse(Exception x)
        {
            LoggerService.LogException(x);

            var message = x.ToString();

            return FailedResponse(message, message);
        }

        protected virtual Response<T> LogExceptionAndReturnFailedResponse<T>(T result, Exception x)
        {
            LoggerService.LogException(x);

            var message = x.ToString();

            return FailedResponse(result, message);
        }

        protected virtual Response<T> LogMessageAndReturnFailedResponse<T>(T result, string message)
        {
            LoggerService.LogEvent(message);

            return FailedResponse(result, message);
        }

        protected virtual Response<string> LogMessageAndReturnFailedResponse(string message)
        {
            LoggerService.LogEvent(message);

            return FailedResponse(message, message);
        }
    }
}