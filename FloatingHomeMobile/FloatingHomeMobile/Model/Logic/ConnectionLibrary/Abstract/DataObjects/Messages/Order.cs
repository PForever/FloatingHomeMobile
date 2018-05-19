using System;
using System.Collections.Generic;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.Containers;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.Messages
{
    public class Order : IMessage
    {
        public DateTime TimeMarker { get; set; }
        public MessageType MessageType { get; set; }
        public string DeviceCode { get; set; }
        public PropertiesValues SetPropertiesValues { get; set; }
        public List<string> GetPropertiesValues { get; set; }
        public string TargetDeviceCode { get; set; }

        public Order()
        {
            
        }
        public Order(string deviceCode, DateTime timeMarker, string targetDeviceCode, PropertiesValues setPropertiesValues = null, List<string> getPropertiesValues = null)
        {
            TimeMarker = timeMarker;
            TargetDeviceCode = targetDeviceCode;
            DeviceCode = deviceCode;
            SetPropertiesValues = setPropertiesValues;
            GetPropertiesValues = getPropertiesValues;
            MessageType = MessageType.Order;
        }
    }
}