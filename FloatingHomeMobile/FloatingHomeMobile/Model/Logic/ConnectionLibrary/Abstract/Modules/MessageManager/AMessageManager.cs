using System;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Handlers.Args;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager
{
    public abstract class AMessageManager : AConnecter, IFullMessageReceiver, IFullMessageSender
    {
        protected AConnectionWorker Worker;

        public abstract event Action<object, EventRequestArgs> RequestReceived;
        public abstract event Action<object, EventTelemetryArgs> TelemetryReceived;
        public abstract event Action<object, EventMessageConnectArgs> ConnectMessageReceived;
        public abstract event Action<object, EventErrArgs> ErrorMessageReceived;
        public abstract event Action<object, EventCommandMessageArgs> CommandMessageReceived;
        public abstract void OnRequest(object sender, EventRequestArgs args);
        public abstract void OnConnectMessage(object sender, EventMessageConnectArgs args);
        public abstract void OnCommandMessage(object sender, EventCommandMessageArgs args);
        public abstract void OnTelemetry(object sender, EventTelemetryArgs args);
        public abstract void OnEventErrorMessage(object sender, EventErrArgs args);
        public abstract void OnOrder(object sender, EventOrderArgs args);
    }
}