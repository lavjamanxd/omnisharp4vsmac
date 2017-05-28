using System;
using Newtonsoft.Json;
using OmniSharp.Server.Abstract;
using OmniSharp.Server.Communication.Messages;

namespace OmniSharp.Server.Communication
{
    public class CommunicationHandler : ICommunicationHandler
    {
        public ResponseBase ProcessMessage(string message)
        {
            try
            {

#if DEBUG
                Console.WriteLine("STDOUT: " + message);
#endif

                var deserializedResponse = JsonConvert.DeserializeObject<ResponseBase>(message);
                return deserializedResponse;
            }
            catch
            {
            }
            return null;
        }
    }
}
