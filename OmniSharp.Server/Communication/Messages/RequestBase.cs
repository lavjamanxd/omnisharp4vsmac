using Newtonsoft.Json;

namespace OmniSharp.Server.Communication.Messages
{
    public abstract class RequestBase<T> : PacketBase, IRequest<T> where T : BaseArguments
    {
        public int Seq { get; set; }
        public virtual string Command { get; }

        [JsonProperty(PropertyName = "arguments")]
        public T BaseArguments { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}