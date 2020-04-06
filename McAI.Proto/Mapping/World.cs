using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Mapping
{
    public class World
    {
        public Dictionary<(int x, int z), ChunkColumn> Chunks { get; private set; }
        public World()
        {
            Chunks = new Dictionary<(int x, int z), ChunkColumn>();
        }
    }
}
