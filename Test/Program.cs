using System;
using OmniSharp.Server;
using OmniSharp.Server.Builder;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var asdasd = 1;
            var server = Server.Instance;
            server.InitializeServer("d:\\home\\repo\\omnisharp-roslyn\\src\\OmniSharp\\bin\\Debug\\net46\\OmniSharp.exe", "d:\\home\\repo\\omnisharp4vsmac\\Test\\");
            server.ExecuteRequest(RequestBuilder.Rename.In("d:\\home\\repo\\omnisharp4vsmac\\Test\\Program.cs").To("retek").At(11, 20).Build(), Callback);
            Console.ReadKey();
            server.TerminateProcess();
        }

        private static void Callback(object o)
        {

        }
    }
}
