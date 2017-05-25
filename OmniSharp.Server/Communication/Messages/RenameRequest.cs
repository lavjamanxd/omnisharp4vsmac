namespace OmniSharp.Server.Communication.Messages
{
    public class RenameRequest : RequestBase<RenameArguments>
    {
        public override string Command => "rename";

        public RenameRequest()
        {
            Seq = 1;
            BaseArguments = new RenameArguments { FileName = "d:\\home\\repo\\omnisharp4vsmac\\OmniSharp.Server\\Program.cs", Line = 12, Column = 58, RenameTo = "comm" };
        }
    }
}