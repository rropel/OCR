using System;

namespace OCR.Core.ServiceContracts
{
    public interface INetworkingService
    {
        bool IsHostReachable(string host);

        bool IsInternetConnected { get; }

        NetworkStatus ConnectionType { get; }

        void OnNetworkChangeReceive(NetworkStatus connectionType);

        event EventHandler<bool> ConnectivityChanged;
    }

    public enum NetworkStatus
    {
        NotReachable,
        ReachableViaCarrierDataNetwork,
        ReachableViaWiFiNetwork
    }
}