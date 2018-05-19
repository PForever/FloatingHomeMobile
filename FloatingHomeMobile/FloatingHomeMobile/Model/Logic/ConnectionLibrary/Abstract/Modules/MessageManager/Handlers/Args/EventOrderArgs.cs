using System;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.Containers;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.Messages;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Handlers.Args
{
    public class EventOrderArgs : EventArgs, IEventIMessageArgs
    {
        public Order Order { get; }
        public EventOrderArgs(Order order)
        {
            Order = order;
        }

        public IMessage Message => Order;
    }
}