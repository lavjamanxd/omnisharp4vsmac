using System;
using OmniSharp.Server.Communication;

namespace OmniSharp.Server
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            var server = Server.Instance;
            server.SetCommunicationHandler(new CommunicationHandler());

            server.ExecuteRequest("{}");

            Console.ReadKey();
        }

    }
}
