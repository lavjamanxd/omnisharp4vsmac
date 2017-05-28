using System;
using OmniSharp.Server.Communication.Messages;

namespace OmniSharp.Server.Builder
{
    public abstract class RequestBuilderBase<T, TArg> where T : RequestBase where TArg : BaseArguments
    {
        protected T Request;

        protected RequestBuilderBase()
        {
            Request = Activator.CreateInstance<T>();
            Request.Arguments = Activator.CreateInstance<TArg>();
        }

        public T Build()
        {
            return Request;
        }

        public RequestBuilderBase<T, TArg> At(int line, int column)
        {
            Request.Arguments.Line = line;
            Request.Arguments.Column = column;
            return this;
        }
    }
}