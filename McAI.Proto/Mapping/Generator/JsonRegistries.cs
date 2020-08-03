using System.Collections.Generic;

namespace McAI.Proto.Mapping.Generator
{
    public class JsonRegistries
    {
        public string Default { get; set; }
        public int Protocol_id { get; set; }
        public Dictionary<string, ItemDictionary> Entries { get; set; }
    }

    public class ItemDictionary
    {
        public int Protocol_id { get; set; }
    }
}
