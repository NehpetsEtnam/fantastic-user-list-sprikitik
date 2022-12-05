using Xamarin.Essentials;

namespace Users.Essentials
{
    public class Connectivity : IConnectivity
    {
        public bool IsConnected() => Xamarin.Essentials.Connectivity.NetworkAccess == NetworkAccess.Internet;
    }
}
