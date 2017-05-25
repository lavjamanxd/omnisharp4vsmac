namespace OmniSharp.Server.Communication.Messages
{
    public interface IResponse : IPacket
    {
        int Request_seq { get; set; }

        string Command { get; set; }

        bool Running { get; set; }

        bool Success { get; set; }

        string Message { get; set; }

        object Body { get; set; }
    }
}
