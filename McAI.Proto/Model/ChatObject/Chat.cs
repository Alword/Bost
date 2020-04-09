using System.Collections.Generic;
using System.Linq;

namespace McAI.Proto.Model.ChatObject
{
    public class Chat
    {
        public string color { get; set; }
        public string translate { get; set; }
        public List<With> with { get; set; }

        public string GetSenderName()
        {
            With name = with.FirstOrDefault(w => w.Insertion != string.Empty);
            if (name != null)
                return name.Insertion;
            return string.Empty;
        }

        public string GetText()
        {
            With value = with.FirstOrDefault(w => w.Text != string.Empty);
            if (value != null)
                return value.Text;
            return string.Empty;
        }
    }
}
