using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.Containers;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.DeviceInfo;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.DataObjects.Messages;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Handlers.Args;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Modules.MessageManager;
using FloatingHomeMobile.Model.Logic.LogFactory;

namespace FloatingHomeMobile.Model
{
    public class MainActivityModel
    {
        #region Consts

        private const string MulticastHostint = "239.0.0.222";
        private const int UdpPort = 8083;
        private const int TcpPort = 8082;

        private static string _host = "krakadile";
        private static string _myCode = "phone1";

        #endregion

        private readonly ServerManager _server;
        private readonly SenderManager _sender;
        private readonly MessageManager _messageManager;

        public MainActivityModel()
        {
            _sender = new SenderManager(MulticastHostint, TcpPort, UdpPort);
            _server = new ServerManager(MulticastHostint, UdpPort, TcpPort);
            _server.ServerStart();
            _messageManager = new MessageManager(MulticastHostint, _myCode, _sender, _server, new []{_host});
            _messageManager.RequestReceived += PopHandler;
            PropNames = new List<string>{"Temperature"};
        }

        public void Connect()
        {
            Device device = new Device(_myCode, "LEND", "Я СМАРТФОН", null);
            ConnectMessage connect = new ConnectMessage(device, _myCode, DateTime.Now, _host);
            _messageManager.OnConnectMessage(null, new EventMessageConnectArgs(connect));
        }

        ~MainActivityModel()
        {
            _server?.Dispose();
            _sender?.Dispose();
        }
        public MainActivityModel(string remoteMessage, string localMessage) : this()
        {
            RemoteMessage = remoteMessage;
            LocalMessage = localMessage;
        }

        #region Properies

        #region RemoteMessage
        private string _remoteMessage;
        public string RemoteMessage
        {
            get => _remoteMessage;
            set
            {
                _remoteMessage = value;
                _RemoteMessageChanged?.Invoke(value);
            }
        }

        private event Action<string> _RemoteMessageChanged;
        public event Action<string> RemoteMessageChanged
        {
            add => _RemoteMessageChanged += value;
            remove => _RemoteMessageChanged -= value;
        }
        #endregion
        public Request Request { get; set; }
        public string LocalMessage { get; set; }
        public string RemoteIp { get; set; }
        public string Protocol { get; set; }
        public List<string> PropNames { get; set; }
        #endregion

        #region Pop

        private void PopHandler(object sender, EventRequestArgs messageArgs)
        {
            Request = messageArgs.RequestInfo;
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, Device> device in Request.Devices)
            {
                var tel = Request.Telemetries[device.Value.Code].First();
                sb.Append(device.Value.Code).Append(": [").Append(tel.TimeMarker).Append("]\n\r\t");
                foreach (KeyValuePair<string, string> telValue in tel.Values)
                {
                    sb.Append(telValue.Key).Append(" = ").Append(telValue.Value).Append("\n\r");
                }
            }
            RemoteMessage += sb.ToString();
        }

        #endregion
        public void PushHandler()
        {
            var order = new Order(_myCode, DateTime.Now, _host, getPropertiesValues: new List<string>{LocalMessage});
            _messageManager.OnOrder(this, new EventOrderArgs(order));
        }
    }
}