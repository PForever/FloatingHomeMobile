using System.Net.Sockets;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Clients.Protocoles
{
    public interface ITcpClient
    {
        TcpClient TcpClient { get; }
    }
}