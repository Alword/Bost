using System.Collections.Generic;

namespace Bost.Proto.Model.ChatObject
{
    public class With
    {
        public string Insertion { get; set; }
        public ClickEvent ClickEvent { get; set; }
        public HoverEvent HoverEvent { get; set; }
        public List<Extra> Extra { get; set; }
        public string Text { get; set; }
    }
}
