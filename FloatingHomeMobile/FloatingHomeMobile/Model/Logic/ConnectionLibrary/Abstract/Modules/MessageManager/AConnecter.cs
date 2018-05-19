using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Parse;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager
{
    public abstract class AConnecter
    {
        protected IObjectParser Sender;
        protected IMessageParser Server;
    }
}