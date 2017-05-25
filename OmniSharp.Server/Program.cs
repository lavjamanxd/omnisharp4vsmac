using System;
using OmniSharp.Server.Communication;
using OmniSharp.Server.Communication.Messages;

namespace OmniSharp.Server
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            var server = Server.Instance;
            server.SetCommunicationHandler(new CommunicationHandler());

            var json = new RenameRequest().ToString();
            server.ExecuteRequest(json);

            Console.ReadKey();
        }

    }
}
