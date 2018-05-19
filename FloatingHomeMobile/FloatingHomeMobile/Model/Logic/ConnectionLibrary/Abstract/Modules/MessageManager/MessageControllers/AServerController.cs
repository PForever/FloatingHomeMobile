using System;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Clients;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.MessageControllers
{
    public abstract class AServerController : IDisposable
    {
        protected abstract TcpServer TcpServer { get; }
        protected abstract UdpServer UdpServer { get; }
        public abstract void Dispose();
    }
}