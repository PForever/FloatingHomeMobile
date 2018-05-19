using System;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.Containers;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Clients.Protocoles.Containers;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Handlers.Args;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager
{
    public abstract class AConnectionWorker : AAddressManager
    {
        protected abstract ConnectionResult GetIp(string deviceCode, TimeSpan timeOut, out string ip);
        protected abstract ConnectionResult UpdateAddressBook(string deviceCode, AddressBook addressBook);
        public abstract ConnectionResult OpenDeviceConnection(string deviceCode, out RemoteHostInfo hostInfo);
    }
}