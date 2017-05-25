using System;
using Newtonsoft.Json;
using OmniSharp.Server.Abstract;
using OmniSharp.Server.Communication.Messages;

namespace OmniSharp.Server.Communication
{
    public class CommunicationHandler : ICommunicationHandler
    {
        public void ProcessMessage(string message)
        {
            try
            {
                var deserializedResponse = JsonConvert.DeserializeObject<ResponseBase>(message);
                if (deserializedResponse.Command.Equals("rename"))
                {
                    var renameResponse = JsonConvert.DeserializeObject<RenameResponse>(deserializedResponse.Body.ToString());
                }
            }
            catch
            {

            }
            Console.WriteLine(message);
        }
    }
}
