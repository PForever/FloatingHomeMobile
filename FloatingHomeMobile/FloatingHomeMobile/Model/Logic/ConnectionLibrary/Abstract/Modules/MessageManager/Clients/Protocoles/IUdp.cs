using System;
using System.Net.Sockets;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Clients.Protocoles
{
    public interface IUdp : IDisposable
    {
        UdpClient UdpClient { get; }
    }
}