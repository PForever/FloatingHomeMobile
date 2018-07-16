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
        //private static string _setDevice = "pikachu";
        private static string _albom = "albom1";
        private static string _myCode = "phone1";

        //private static string PropName1 = "TemperatureHolder";
        //private static string PropName2 = "Temperature";
        private static string PropName3 = "AlbomPosition";
        private Dictionary<string, PropertiesValues> _setProps;
        private static readonly Random Rnd = new Random();
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
            PropNames = new List<string>{ /*PropName1, PropName2,*/ PropName3 };
            _setProps = new Dictionary<string, PropertiesValues>
            {
                //{ _setDevice, new PropertiesValues { { PropName1, "" } } },
                {_albom, new PropertiesValues{{PropName3, ""}} }
            };

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
                foreach (Telemetry telemetry in Request.Telemetries[device.Value.Code])
                {
                    sb.Append(device.Value.Code).Append(": [").Append(telemetry.TimeMarker).Append("]\n\r\t");
                    foreach (KeyValuePair<string, string> telValue in telemetry.Values)
                    {
                        sb.Append(telValue.Key).Append(" = ").Append(telValue.Value).Append("\n\r");
                    }
                }

            }
            RemoteMessage += sb.ToString();
        }

        #endregion
        public void PushHandler()
        {
            //_setProps[_setDevice][PropName1] = Rnd.Next(20, 30).ToString();
            _setProps[_albom][PropName3] = LocalMessage;
            var getProps = new Dictionary<string, List<string>>{{_host, PropNames}};
            var order = new Order(_myCode, DateTime.Now, _host, setPropertiesValues: _setProps, getPropertiesValues: getProps);
            _messageManager.OnOrder(this, new EventOrderArgs(order));
        }
    }
}