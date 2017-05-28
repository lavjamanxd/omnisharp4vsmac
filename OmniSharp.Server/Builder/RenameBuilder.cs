using OmniSharp.Server.Communication.Messages;

namespace OmniSharp.Server.Builder
{
    public class RenameBuilder : RequestBuilderBase<RenameRequest>
    {
        public RenameBuilder()
        {
            Request.Arguments = new RenameArguments();
        }

        public RenameBuilder To(string to)
        {
            Request.Arguments.RenameTo = to;
            return this;
        }

        public RenameBuilder In(string filePath)
        {
            Request.Arguments.FileName = filePath;
            return this;
        }
    }
}