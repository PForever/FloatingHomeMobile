using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Server;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Clients.Protocoles.Containers
{
    public class ConnectionPort : IConnectPoint<int>
    {
        public int Value { get; set; }
    }
}