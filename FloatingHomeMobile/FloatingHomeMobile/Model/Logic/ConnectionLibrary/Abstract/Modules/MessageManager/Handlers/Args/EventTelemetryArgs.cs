using System;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.Containers;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.Messages;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Handlers.Args
{
    public class EventTelemetryArgs : EventArgs, IEventIMessageArgs
    {
        public Telemetry TelemetryInfo { get; }
        public EventTelemetryArgs(Telemetry telemetryInfo)
        {
            TelemetryInfo = telemetryInfo;
        }

        public IMessage Message => TelemetryInfo;
    }
}