using System;
using System.Collections.Generic;
using System.Text;

namespace Bost.Proto.Model
{
    public class ServerStatus
    {
        public Version Version { get; set; }
        public Description Description { get; set; }
        public Players Players { get; set; }
        public string Favicon { get; private set; }

        public static ServerStatus Empty = new ServerStatus()
        {
            Version = new Version()
            {
                Name = "",
                Protocol = -1
            }
        };
    }

    public class Version
    {
        public string Name { get; set; }
        public int Protocol { get; set; }
    }
    public class Players
    {
        public int Max { get; set; }
        public int Online { get; set; }
        public List<SamplePlayer> Sample { get; set; }
    }

    public class SamplePlayer
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }
    public class Description
    {
        public string Text { get; set; }
    }
}
