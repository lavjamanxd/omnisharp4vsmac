namespace OmniSharp.Server.Communication.Messages
{
    public class RenameArguments : BaseArguments
    {
        public bool WantsTextChanges { get; set; }
        public bool ApplyTextChanges { get; set; } = true;

        public string RenameTo { get; set; }
    }
}