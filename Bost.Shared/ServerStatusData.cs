using System;

namespace Bost.Shared
{
    public class ServerStatusData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoreName { get; set; }
        public int Proto { get; set; }
        public int Online { get; set; }
        public int Max { get; set; }
        public string OnlineMax { get => $"{Online}/{Max}"; }
    }
}
