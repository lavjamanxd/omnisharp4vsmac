using System;
using OmniSharp.Server.Abstract;

namespace OmniSharp.Server.Communication
{
    public class CommunicationHandler : ICommunicationHandler
    {
        public CommunicationHandler()
        {

        }

        public void ProcessMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
