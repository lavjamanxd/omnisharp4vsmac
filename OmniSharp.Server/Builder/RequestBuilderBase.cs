using System;
using OmniSharp.Server.Communication.Messages;

namespace OmniSharp.Server.Builder
{
    public abstract class RequestBuilderBase<T> where T : RequestBase
    {
        protected T Request;

        protected RequestBuilderBase()
        {
            Request = Activator.CreateInstance<T>();
        }

        public T Build()
        {
            return Request;
        }

        public RequestBuilderBase<T> At(int line, int column)
        {
            Request.Arguments.Line = line;
            Request.Arguments.Column = column;
            return this;
        }
    }
}