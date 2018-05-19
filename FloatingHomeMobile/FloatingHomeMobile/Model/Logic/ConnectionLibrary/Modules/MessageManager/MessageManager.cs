using System;
using System.Collections.Generic;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Handlers.Args;
using FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Modules.MessageManager.Parse;
using FloatingHomeMobile.Model.Logic.LogFactory;

namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Modules.MessageManager
{
    public class MessageManager : AFullMessageReceiver, ILoggable
    {
        private readonly TimeSpan _timeOut = new TimeSpan(0, 0, 10);
        //TODO создать сохранение и чтение связки код-макадрес в/из бд. Читать через ConnectionWorker
        public MessageManager(string multicastHost, string myCode, IObjectParser sender, IMessageParser server, IList<string> hostCodes)
        {
            Logger = Logging.Log;
            Logger.Debug("MessageManager Create");


            Sender = sender;
            Server = server;

            AddHandlers();
            Worker = new ConnectionWorker(multicastHost, _timeOut, sender, server, myCode, hostCodes);
        }

        private void AddHandlers()
        {
            Server.CommandMessageReceived += EventCommandMessageHandler;
            Server.ConnectMessageReceived += EventConnectMessageHandler;
            Server.RequestReceived += EventRequestHandler;
            Server.TelemetryReceived += EventTelemetryHandler;
            Server.ErrorMessageReceived += EventErrHandler;
            //TODO валидатор
        }

        #region ReceiveHandler

        //TODO ввести тип сообщения Эхо для установки канала соединения 
        protected override void EventRequestHandler(RemoteHostInfo remoteHost, EventRequestArgs args)
        {
            Logger.Debug($"MessageManager.EventRequestHandler Invoked for ({remoteHost.Host} via {remoteHost.Protocol} code: {args.Message.DeviceCode})");
            _RequestReceived?.Invoke(this, args);
        }

        protected override void EventConnectMessageHandler(RemoteHostInfo remoteHost, EventMessageConnectArgs args)
        {
            Logger.Debug($"MessageManager.EventConnectMessageHandler Invoked for ({remoteHost.Host} via {remoteHost.Protocol} code: {args.Message.DeviceCode})");
            _ConnectMessageReceived?.Invoke(this, args);
        }

        protected override void EventCommandMessageHandler(RemoteHostInfo remoteHost, EventCommandMessageArgs args)
        {
            Logger.Debug($"MessageManager.EventCommandMessageHandler Invoked for ({remoteHost.Host} via {remoteHost.Protocol} code: {args.Message.DeviceCode})");
            _CommandMessageReceived?.Invoke(this, args);
        }

        protected override void EventTelemetryHandler(RemoteHostInfo remoteHost, EventTelemetryArgs args)
        {
            Logger.Debug($"MessageManager.EventTelemetryHandler Invoked for ({remoteHost.Host} via {remoteHost.Protocol} code: {args.Message.DeviceCode})");
            //DbManager.AddData(args.TelemetryInfo);
            _TelemetryReceived?.Invoke(this, args);
        }

        protected override void EventErrHandler(RemoteHostInfo remoteHost, EventErrArgs args)
        {
            Logger.Debug($"MessageManager.EventErrHandler Invoked for ({remoteHost.Host} via {remoteHost.Protocol} code: {args.Message.DeviceCode})");
            _ErrorMessageReceived?.Invoke(this, args);
        }

        protected override void EventOrderHandler(RemoteHostInfo remoteHost, EventOrderArgs args)
        {
            Logger.Debug($"MessageManager.EventOrderHandler Invoked for ({remoteHost.Host} via {remoteHost.Protocol} code: {args.Message.DeviceCode})");
            throw new NotImplementedException();
        }

        #endregion

        #region Events

        private event Action<object, EventRequestArgs> _RequestReceived;
        public override event Action<object, EventRequestArgs> RequestReceived
        {
            add => _RequestReceived += value;
            remove => _RequestReceived -= value;
        }

        private event Action<object, EventTelemetryArgs> _TelemetryReceived;
        public override event Action<object, EventTelemetryArgs> TelemetryReceived
        {
            add => _TelemetryReceived += value;
            remove => _TelemetryReceived -= value;
        }

        private event Action<object, EventMessageConnectArgs> _ConnectMessageReceived;
        public override event Action<object, EventMessageConnectArgs> ConnectMessageReceived
        {
            add => _ConnectMessageReceived += value;
            remove => _ConnectMessageReceived -= value;
        }

        private event Action<object, EventErrArgs> _ErrorMessageReceived;
        public override event Action<object, EventErrArgs> ErrorMessageReceived
        {
            add => _ErrorMessageReceived += value;
            remove => _ErrorMessageReceived -= value;
        }

        private event Action<object, EventCommandMessageArgs> _CommandMessageReceived;
        public override event Action<object, EventCommandMessageArgs> CommandMessageReceived
        {
            add => _CommandMessageReceived += value;
            remove => _CommandMessageReceived -= value;
        }

        #endregion

        #region OnReceived

        public ILogger Logger { get; }
        //TODO все войды заменить на проброс ошибок. Шоб было
        public override void OnRequest(object sender, EventRequestArgs args)
        {
            Logger.Debug($"MessageManager.OnRequest Invoked from {sender} code: {args.Message.TargetDeviceCode}");
            var err = Worker.OpenDeviceConnection(args.Message.TargetDeviceCode, out RemoteHostInfo connectInfo);
            if (err != 0) return;
            Sender.OnRequest(connectInfo, args);
        }

        public override void OnConnectMessage(object sender, EventMessageConnectArgs args)
        {
            Logger.Debug($"MessageManager.OnRequest Invoked from {sender} code: {args.Message.TargetDeviceCode}");
            var err = Worker.OpenDeviceConnection(args.Message.TargetDeviceCode, out RemoteHostInfo connectInfo);
            if (err != 0) return;
            Sender.OnConnectMessage(connectInfo, args);
        }

        public override void OnCommandMessage(object sender, EventCommandMessageArgs args)
        {
            Logger.Debug($"MessageManager.OnRequest Invoked from {sender} code: {args.Message.TargetDeviceCode}");
            var err = Worker.OpenDeviceConnection(args.Message.TargetDeviceCode, out RemoteHostInfo connectInfo);
            if (err != 0) return;
            Sender.OnCommandMessage(connectInfo, args);
        }

        public override void OnTelemetry(object sender, EventTelemetryArgs args)
        {
            Logger.Debug($"MessageManager.OnRequest Invoked from {sender} code: {args.Message.TargetDeviceCode}");
            var err = Worker.OpenDeviceConnection(args.Message.TargetDeviceCode, out RemoteHostInfo connectInfo);
            if (err != 0) return;
            Sender.OnTelemetry(connectInfo, args);
        }

        public override void OnEventErrorMessage(object sender, EventErrArgs args)
        {
            Logger.Debug($"MessageManager.OnRequest Invoked from {sender} code: {args.Message.TargetDeviceCode}");
            var err = Worker.OpenDeviceConnection(args.Message.TargetDeviceCode, out RemoteHostInfo connectInfo);
            if (err != 0) return;
            Sender.OnEventErrorMessage(connectInfo, args);
        }

        public override void OnOrder(object sender, EventOrderArgs args)
        {
            Logger.Debug($"MessageManager.OnRequest Invoked from {sender} code: {args.Message.TargetDeviceCode}");
            var err = Worker.OpenDeviceConnection(args.Message.TargetDeviceCode, out RemoteHostInfo connectInfo);
            if (err != 0) return;
            Sender.OnOrder(connectInfo, args);
        }

        #endregion
    }
}