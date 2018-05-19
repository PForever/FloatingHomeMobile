using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Handlers.Args;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Handlers.Delegates
{
    public delegate void EventMessageConnectHandler(RemoteHostInfo remoteHost, EventMessageConnectArgs args);
}