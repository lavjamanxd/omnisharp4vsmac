using System.Collections.Generic;

namespace OmniSharp.Server.Communication.Queue
{
    public class RequestQueue
    {
        public readonly Dictionary<int, RequestEntry> Queue = new Dictionary<int, RequestEntry>();

        public void RegisterEntryToQueue(RequestEntry entry)
        {
            Queue[entry.Id] = entry;
        }

        public void ProcessEntry(int id, object data)
        {
            if (!Queue.ContainsKey(id)) return;

            Queue[id].HandlerCallback?.Invoke(data);
            Queue[id] = null;
        }
    }
}