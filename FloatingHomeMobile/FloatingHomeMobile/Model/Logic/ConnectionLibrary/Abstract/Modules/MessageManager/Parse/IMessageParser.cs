using System;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Handlers.Args;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Server;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Parse
{
    public interface IMessageParser
    {
        //TODO попробовать переделать в шаблоны не убив сериализацию
        event Action<RemoteHostInfo, EventRequestArgs> RequestReceived;
        event Action<RemoteHostInfo, EventTelemetryArgs> TelemetryReceived;
        event Action<RemoteHostInfo, EventMessageConnectArgs> ConnectMessageReceived;
        event Action<RemoteHostInfo, EventErrArgs> ErrorMessageReceived;
        event Action<RemoteHostInfo, EventCommandMessageArgs> CommandMessageReceived;
        event Action<RemoteHostInfo, EventCallArgs> CallReceived;
        event Action<RemoteHostInfo, EventOrderArgs> OrderReceived;
        void EventDataHandler(object sender, EventDataArg<string> e);
        void TcpStart();
        void TcpStop();
    }
}