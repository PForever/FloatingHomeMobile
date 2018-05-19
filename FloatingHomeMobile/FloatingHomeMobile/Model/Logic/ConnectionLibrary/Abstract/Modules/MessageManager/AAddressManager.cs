using System.Collections.Generic;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Clients.Protocoles.Containers;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager
{
    public abstract class AAddressManager : AConnecter
    {
        protected AddressBook AddressBook;
        protected abstract AddressBook GetAddressBookDb(IList<string> hostCodes);
    }
}