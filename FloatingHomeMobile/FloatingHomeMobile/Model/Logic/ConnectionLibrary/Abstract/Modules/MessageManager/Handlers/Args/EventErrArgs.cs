using System;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.Containers;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.Messages;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Handlers.Args
{
    public class EventErrArgs : EventArgs, IEventIMessageArgs
    {
        public ErrorMessage ErrorMessage { get; }

        public IMessage Message => ErrorMessage;

        public EventErrArgs(ErrorMessage errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}