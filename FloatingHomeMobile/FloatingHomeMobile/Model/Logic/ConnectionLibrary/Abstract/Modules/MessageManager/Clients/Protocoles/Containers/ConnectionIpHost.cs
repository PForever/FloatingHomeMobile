using System.Net;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Server;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Clients.Protocoles.Containers
{
    public class ConnectionIpHost : IConnectPoint<IPEndPoint>
    {
        public IPEndPoint Value { get; set; }
    }
}