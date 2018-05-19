using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.Containers;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.Messages;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Parse
{
    public interface IParsing
    {
        Request Request { get; }
        Telemetry Telemetry { get; }
        MessageType MessageType { get; }
        string ErrInfo { get; }
    }
}