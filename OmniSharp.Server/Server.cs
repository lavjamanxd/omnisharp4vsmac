using System.Diagnostics;
using OmniSharp.Server.Abstract;

namespace OmniSharp.Server
{
    public sealed class Server
    {
        private static volatile Server _instance;
        private static readonly object Lock = new object();

        private readonly Process _process;
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
                if (_instance != null) return _instance;
                lock (Lock)
                {
                    if (_instance == null)
                        _instance = new Server();
                }

                return _instance;
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
            startInfo.Arguments = "--stdio --source d:\\home\\repo\\omnisharp4vsmac\\OmniSharp.Server\\";
            startInfo.FileName = "d:\\home\\repo\\omnisharp-roslyn\\src\\OmniSharp\\bin\\Debug\\net46\\OmniSharp.exe";
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
