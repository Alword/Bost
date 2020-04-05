using McAI.Proto.Extentions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Mapping.Generator
{
    public static class GlobalPalette
    {
        public static void ReadBlocks()
        {
            string json = "blocks.json".ReadResource();
            JsonBlocks account = JsonConvert.DeserializeObject<JsonBlocks>(json);
        }
    }
}
