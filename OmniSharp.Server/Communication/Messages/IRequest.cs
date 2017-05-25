namespace OmniSharp.Server.Communication.Messages
{
    public interface IRequest<T>
    {
        string Command { get; }
        T BaseArguments { get; set; }
    }
}
