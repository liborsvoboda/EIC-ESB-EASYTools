using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;

namespace RemoteDesktopVNCClientApp
{
    class LocalAddressService
    {
        public List<IPAddress> GetLocalIpAddress()
        {
            List<IPAddress> localAddress = new List<IPAddress>();

            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface adapter in adapters)
            {
                if (adapter.OperationalStatus.Equals(OperationalStatus.Up))
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    foreach (IPAddressInformation ipInfo in properties.UnicastAddresses)
                    {
                        localAddress.Add(ipInfo.Address);
                    }
                }
            }

            return localAddress;
        }
    }
}
