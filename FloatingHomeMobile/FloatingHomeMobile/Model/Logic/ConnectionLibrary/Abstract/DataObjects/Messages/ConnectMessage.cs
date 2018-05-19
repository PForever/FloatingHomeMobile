using System;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.Containers;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.DeviceInfo;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.Messages
{
    public class ConnectMessage : IMessage
    {
        public Device Device { get; set; }

        public ConnectMessage(Device device, string deviceCode, DateTime timeMarker, string targetDeviceCode)
        {
            TimeMarker = timeMarker;
            TargetDeviceCode = targetDeviceCode;
            Device = device;
            DeviceCode = deviceCode;
            MessageType = MessageType.Connect;
        }
        public ConnectMessage(IDevice device, string deviceCode, DateTime timeMarker, string targetDeviceCode) : this(new Device(device), deviceCode, timeMarker, targetDeviceCode) { }

        public DateTime TimeMarker { get; set; }
        public MessageType MessageType { get; set; }
        public string DeviceCode { get; set; }
        public string TargetDeviceCode { get; set; }
    }
}