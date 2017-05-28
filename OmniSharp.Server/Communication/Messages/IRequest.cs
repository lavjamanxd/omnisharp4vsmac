namespace OmniSharp.Server.Communication.Messages
{
    public interface IRequest<T>
    {
        string Command { get; }
        T Arguments { get; set; }
    }
}
