using System;
using System.Diagnostics;

namespace McAI.Proto.Commands
{
    public abstract class Command
    {
        protected GameState gameState;
        private readonly bool isLogging;
        public Command(bool isLogging = false)
        {
            this.isLogging = isLogging;
        }
        public abstract void Execute(byte[] array);

        [Conditional("DEBUG")]
        protected void Debug(string log)
        {
            if (isLogging)
            {
                Console.WriteLine(log);
            }
        }
    }
}
