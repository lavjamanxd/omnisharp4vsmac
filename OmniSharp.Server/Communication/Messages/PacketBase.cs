namespace OmniSharp.Server.Communication.Messages
{
    public abstract class PacketBase : IPacket
    {
        public int Seq { get; set; }

        protected static int SeqPool = 1;
    }
}