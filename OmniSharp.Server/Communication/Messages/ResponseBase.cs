namespace OmniSharp.Server.Communication.Messages
{
    public class ResponseBase : PacketBase, IResponse
    {
        public int Request_seq { get; set; }
        public string Command { get; set; }
        public bool Running { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Body { get; set; }
    }
}