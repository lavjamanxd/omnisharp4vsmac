namespace OmniSharp.Server.Communication.Messages
{
    public class RenameRequest : RequestBase<RenameArguments>
    {
        public override string Command => "/rename";
    }
}