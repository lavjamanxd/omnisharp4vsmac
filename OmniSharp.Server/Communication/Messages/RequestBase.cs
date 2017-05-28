using Newtonsoft.Json;

namespace OmniSharp.Server.Communication.Messages
{
    public abstract class RequestBase : PacketBase
    {
        public virtual string Command { get; }

        [JsonProperty(PropertyName = "arguments")]
        public BaseArguments Arguments { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }


    public abstract class RequestBase<T> : RequestBase, IRequest<T> where T : BaseArguments
    {
        public new T Arguments
        {
            get => (T)base.Arguments;
            set => base.Arguments = value;
        }

        protected RequestBase()
        {
            Seq = SeqPool++;
        }
    }
}