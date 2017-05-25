namespace OmniSharp.Server.Communication.Messages
{
    public class BaseArguments
    {
        public int Line { get; set; }
        public int Column { get; set; }
        public string Buffer { get; set; }
        //public IEnumerable<LinePositionSpanTextChange> Changes { get; set; }
        public string FileName { get; set; }
    }
}