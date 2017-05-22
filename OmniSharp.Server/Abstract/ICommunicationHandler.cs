namespace OmniSharp.Server.Abstract
{
    public interface ICommunicationHandler
    {
        void ProcessMessage(string message);
    }
}
