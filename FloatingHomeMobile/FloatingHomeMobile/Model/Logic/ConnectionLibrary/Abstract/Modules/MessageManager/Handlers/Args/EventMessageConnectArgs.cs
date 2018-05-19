using System;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.Containers;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.Messages;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Handlers.Args
{
    public class EventMessageConnectArgs : EventArgs, IEventIMessageArgs
    {
        public EventMessageConnectArgs(ConnectMessage connectMessage)
        {
            ConnectMessage = connectMessage;
        }

        public ConnectMessage ConnectMessage { get; }
        public IMessage Message => ConnectMessage;
    }
}