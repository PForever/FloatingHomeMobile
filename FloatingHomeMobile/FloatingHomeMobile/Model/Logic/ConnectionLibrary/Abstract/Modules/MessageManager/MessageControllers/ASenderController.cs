using System;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Clients;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.MessageControllers
{
    public abstract class ASenderController : IDisposable
    {
        protected abstract TcpSender TcpSender { get; }
        protected abstract UdpSender UdpSender { get; }
        public abstract void Dispose();
    }
}