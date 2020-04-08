using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Model.ChatObject
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
