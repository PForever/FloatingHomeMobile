using System;
using System.Text.RegularExpressions;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.Containers;
using Newtonsoft.Json;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Modules.MessageManager.Serialize
{
    public static class JsonHelp
    {
        public static Regex Pattern = new Regex("\"MessageType\":(\\d)");
        public static MessageType MessageTypeSeacher(ref string message)
        {
            string mt = Pattern.Match(message).Groups[1].Value;
            if (Enum.TryParse(mt, out MessageType result))
                return result;
            //TODO вообще говоря, не надо тут ошибку бросать... но пусть пока будет
            throw new JsonSerializationException("Message has not MessageType parameter");
        }
    }
}