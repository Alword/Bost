using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace McAI.Proto.Mapping.Generator
{
    public class GeneratedBlock
    {
        public List<GeneratedState> States { get; set; }
        public class GeneratedState
        {
            public uint Id { get; set; }
            public bool Default { get; set; }
        }
    }
}
