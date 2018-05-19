﻿using System.Net;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Clients.Protocoles
{
    public static class ProtocolHepler
    {
        public static string GetIp(this EndPoint endPoint)
        {
            string point = endPoint.ToString();
            return point.Substring(0, point.IndexOf(':'));
        }
    }
}