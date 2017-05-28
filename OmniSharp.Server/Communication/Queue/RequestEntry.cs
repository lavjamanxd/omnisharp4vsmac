using System;
using OmniSharp.Server.Communication.Messages;

namespace OmniSharp.Server.Communication.Queue
{
    public class RequestEntry
    {
        private readonly RequestBase _originalRequest;

        public RequestEntry(RequestBase originalRequest)
        {
            _originalRequest = originalRequest;
        }

        public int Id => _originalRequest.Seq;

        public Action<object> HandlerCallback { get; set; }
    }
}