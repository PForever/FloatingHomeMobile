using System;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.Containers;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.DeviceInfo
{
    public interface IDevice : ICloneable
    {
        string Code { get; }
        string MacAddress { get; set; }
        string Name { get; }
        Properties Info { get; }
    }
}