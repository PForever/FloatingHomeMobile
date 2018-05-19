using System;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.Containers;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.Messages;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Handlers.Args
{
    public class EventCommandMessageArgs : EventArgs, IEventIMessageArgs
    {
        public CommandMessage CommandMessage { get; }
        public EventCommandMessageArgs(CommandMessage commandMessage)
        {
            CommandMessage = commandMessage;
        }

        public IMessage Message => CommandMessage;
    }
}