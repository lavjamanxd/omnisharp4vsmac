using System.Diagnostics;
using OmniSharp.Server.Abstract;

namespace OmniSharp.Server
{
    public sealed class Server
    {
        private static volatile Server instance;
        private static object _lock = new object();

        private Process _process;
        private ICommunicationHandler _communicationHandler;

        private Server()
        {
            _process = CreateProcess();
            _process.Start();
            _process.BeginOutputReadLine();
        }

        public static Server Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (_lock)
                    {
                        if (instance == null)
                            instance = new Server();
                    }
                }

                return instance;
            }
        }

        private Process CreateProcess()
        {
            var startInfo = new ProcessStartInfo();
            var process = new Process();

            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardInput = true;
            startInfo.UseShellExecute = false;
            startInfo.Arguments = "--stdio";
            startInfo.FileName = "omnisharp";
            process.EnableRaisingEvents = true;
            process.OutputDataReceived += Process_OutputDataReceived;
            process.StartInfo = startInfo;
            return process;
        }

        public void SetCommunicationHandler(ICommunicationHandler handler)
        {
            _communicationHandler = handler;
        }

        void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            _communicationHandler?.ProcessMessage(e.Data);
        }

        public void ExecuteRequest(string request)
        {
            using (var writer = _process.StandardInput)
            {
                writer.WriteLine(request);
                writer.Flush();
            }
        }
    }
}
