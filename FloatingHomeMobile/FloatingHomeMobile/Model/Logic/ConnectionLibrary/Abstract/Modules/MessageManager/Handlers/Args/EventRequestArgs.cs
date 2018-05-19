using System;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.Containers;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.Messages;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Handlers.Args
{
    public class EventRequestArgs : EventArgs, IEventIMessageArgs
    {
        public Request RequestInfo { get; }
        public EventRequestArgs(Request requestInfo)
        {
            RequestInfo = requestInfo;
        }

        public IMessage Message => RequestInfo;
    }
}