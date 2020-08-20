using Bost.Proto.Model.ChatObject;
using Newtonsoft.Json;

namespace Bost.Proto.Types
{
    public static class McChat
    {
        public static bool TryParse(ref byte[] buffer, out Chat result)
        {
            McString.TryParse(ref buffer, out string chatString);
            if (chatString.Contains("chat.type.text"))
            {
                result = JsonConvert.DeserializeObject<Chat>(chatString);
                return true;
            }
            else
            {
                result = new Chat
                {
                    translate = chatString
                };
                return false;
            }
        }
        public static byte[] ToBytes(Chat value)
        {
            string chatString = JsonConvert.SerializeObject(value);
            return McString.ToBytes(chatString);
        }
    }
}
