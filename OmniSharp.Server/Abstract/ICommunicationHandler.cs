using OmniSharp.Server.Communication.Messages;

namespace OmniSharp.Server.Abstract
{
    public interface ICommunicationHandler
    {
        ResponseBase ProcessMessage(string message);
    }
}
