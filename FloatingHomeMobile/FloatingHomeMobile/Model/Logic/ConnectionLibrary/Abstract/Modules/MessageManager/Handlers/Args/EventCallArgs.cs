using System;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.Containers;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.Messages;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Handlers.Args
{
    public class EventCallArgs : EventArgs, IEventIMessageArgs
    {
        public Call CallInfo { get; }
        public IMessage Message => CallInfo;

        public EventCallArgs(Call callInfo)
        {
            CallInfo = callInfo;
        }
    }
}