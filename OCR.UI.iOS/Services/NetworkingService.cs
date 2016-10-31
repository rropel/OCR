using System;
using OCR.Core.ServiceContracts;
using OCR.UI.iOS.Helpers;

namespace OCR.UI.iOS.Services
{
    public class NetworkingService : INetworkingService
    {
        private const string HOST_TO_TEST = "www.microsoft.com";

        public bool IsHostReachable(string host)
        {
            return Reachability.IsHostReachable(host);
        }

        public bool IsInternetConnected
        {
            get { return Reachability.IsHostReachable(HOST_TO_TEST); }
        }

        public NetworkStatus ConnectionType
        {
            get
            {
                return Reachability.InternetConnectionStatus();
            }
        }

        public void OnNetworkChangeReceive(NetworkStatus connectionType)
        {
            if (ConnectivityChanged != null)
            {
                ConnectivityChanged(this, IsInternetConnected);
            }
        }

        public event EventHandler<bool> ConnectivityChanged;
    }
}