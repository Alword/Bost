using System;
using System.Collections.Generic;
using System.Text;
using McAI.Proto.Model.ChatObject;
using Newtonsoft.Json;

namespace McAI.Proto.Types
{
    public static class McChat
    {
        public static bool TryParse(ref byte[] buffer, out Chat result)
        {
            McString.TryParse(ref buffer, out string chatString);
            result =JsonConvert.DeserializeObject<Chat>(chatString);
            return true;
        }
        public static byte[] ToBytes(Chat value)
        {
            string chatString = JsonConvert.SerializeObject(value);
            return McString.ToBytes(chatString);
        }
    }
}
