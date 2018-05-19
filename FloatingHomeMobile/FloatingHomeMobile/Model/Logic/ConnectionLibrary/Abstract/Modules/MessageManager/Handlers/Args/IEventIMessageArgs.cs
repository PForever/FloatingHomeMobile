using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.Containers;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Handlers.Args
{
    public interface IEventIMessageArgs
    {
        IMessage Message { get; }
    }
}