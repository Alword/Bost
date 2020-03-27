using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Commands
{
    public abstract class Command
    {
        public abstract string Execute(byte[] array);
    }
}
