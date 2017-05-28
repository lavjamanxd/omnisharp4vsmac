using System;
using System.Diagnostics;
using OmniSharp.Server.Abstract;
using OmniSharp.Server.Communication;
using OmniSharp.Server.Communication.Messages;
using OmniSharp.Server.Communication.Queue;

namespace OmniSharp.Server
{
    public sealed class Server
    {
        private static volatile Server _instance;
        private static readonly object Lock = new object();

        private Process _process;
        private readonly RequestQueue _requestQueue = new RequestQueue();

        private ICommunicationHandler _communicationHandler;
        private bool _initialized;

        public void InitializeServer(string omnisharpTarget, string projectPath)
        {
            if (_initialized)
            {
                throw new InvalidOperationException("OmniSharp process already running");
            }

            _communicationHandler = new CommunicationHandler();
            _process = CreateProcess();

            _process.StartInfo.Arguments = "--stdio --source " + projectPath;
            _process.StartInfo.FileName = omnisharpTarget;

            _process.Start();
            _process.BeginOutputReadLine();
            _initialized = true;
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

        public void TerminateProcess()
        {
            CheckProcess();

            _process.Kill();
        }

        private void CheckProcess()
        {
            if (!_initialized)
            {
                throw new InvalidOperationException("OmniSharp process is not running!");
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
            process.EnableRaisingEvents = true;
            process.OutputDataReceived += Process_OutputDataReceived;
            process.StartInfo = startInfo;
            return process;
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            var result = _communicationHandler?.ProcessMessage(e.Data);
            if (result != null)
            {
                _requestQueue.ProcessEntry(result.Request_seq, result.Body);
            }
        }

        public void ExecuteRequest(RequestBase request, Action<object> callback)
        {
            CheckProcess();
            _requestQueue.RegisterEntryToQueue(new RequestEntry(request) { HandlerCallback = callback });

            var requestString = request.ToString();
#if DEBUG
            Console.WriteLine("REQUEST: " + requestString);
#endif

            var writer = _process.StandardInput;
            writer.WriteLine(requestString);
            writer.Flush();
        }
    }
}
