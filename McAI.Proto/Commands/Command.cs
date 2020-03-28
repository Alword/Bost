using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace McAI.Proto.Commands
{
    public abstract class Command
    {
        public abstract void Execute(byte[] array);

        [Conditional("DEBUG")]
        protected void Debug(string log)
        {
            Console.WriteLine(log);
        }
    }
}
