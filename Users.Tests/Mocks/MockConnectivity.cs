using Users.Essentials;

namespace Users.Tests.Mocks
{
    public class MockConnectivity : IConnectivity
    {
        public bool Connected = true;

        public bool IsConnected()
        {
            return Connected;
        }
    }
}
