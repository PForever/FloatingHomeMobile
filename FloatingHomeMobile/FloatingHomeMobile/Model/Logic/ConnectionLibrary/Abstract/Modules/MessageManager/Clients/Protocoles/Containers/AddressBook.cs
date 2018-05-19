using System.Collections.Concurrent;
using System.Collections.Generic;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Clients.Protocoles.Containers
{
    public class AddressBook : ConcurrentDictionary<string, Addresses>
    {
        public AddressBook() : base()
        {
        }
        public AddressBook(IDictionary<string, Addresses> dictionary) : base(dictionary)
        {
        }
    }
}