using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FloatingHomeMobile.Annotations;
using FloatingHomeMobile.Model;
using Xamarin.Forms;

namespace FloatingHomeMobile.ViewModel
{
    public class MainActivityViewModel : INotifyPropertyChanged
    {
        private readonly MainActivityModel _model;
        public ICommand ButtonPush { get; }
        public ICommand ButtonConnect { get; }

        #region RemoteMessage

        public string RemoteMessage
        {
            get => _model.RemoteMessage;
            set => _model.RemoteMessage = value;
        }

        #endregion

        #region LocalMessage

        public string LocalMessage
        {
            get => _model.LocalMessage;
            set => _model.LocalMessage = value;
        }

        #endregion

        #region RemoteIp

        public string RemoteIp
        {
            get => _model.RemoteIp;
            set => _model.RemoteIp = value;
        }

        #endregion

        #region Protocol

        public string Protocol
        {
            get => _model.Protocol;
            set => _model.Protocol = value;
        }

        #endregion

        void PushHandler() => RemoteMessage = LocalMessage;

        public MainActivityViewModel()
        {
            _model = new MainActivityModel();
            _model.RemoteMessageChanged += (value) => OnPropertyChanged(nameof(RemoteMessage)); //TODO Валидация по value

            RemoteMessage = "";
            LocalMessage = "Temperature";
            RemoteIp = "192.168.1.34";
            Protocol = "UDP";

            ButtonPush = new PushCommand(_model.PushHandler);
            ButtonConnect = new PushCommand(_model.Connect);
        }
        #region Noty

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}