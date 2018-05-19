namespace FloatingHomeMobile.Model.Logic.ConnectionLibrary.Abstract.Server
{
    public interface IConnectPoint<T>
    {
        T Value { get; set; }
    }
}