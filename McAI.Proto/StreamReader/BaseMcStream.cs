using McAI.Proto.Abstractions;
using McAI.Proto.Enum;
using McAI.Proto.Model;
using System;
using System.Collections.Generic;

namespace McAI.Proto.StreamReader
{
    public class BaseMcStream
    {
        protected int length = 0;
        protected List<byte> queue = new List<byte>();
        protected readonly Func<GameStates> getState;
        protected readonly Dictionary<GameStates, ICommand<int, byte[]>> readers;

        public BaseMcStream(Dictionary<GameStates, ICommand<int, byte[]>> readers, Func<GameStates> getState)
        {
            this.getState = getState;
            this.readers = readers;
        }
        public virtual void Read(byte[] array)
        {
            queue.AddRange(array);
            while (length < queue.Count)
            {
                array = queue.ToArray();
                Varint.TryParse(array, out int numread, out length);
                if (length > queue.Count - numread) break;

                array = array[numread..(length + 1)];

                queue.RemoveRange(0, length + numread);

                var state = getState();
                if (readers.ContainsKey(state))
                {
                    readers[state].Execute(length, array);
                }
                else
                {
                    Console.WriteLine($"Unknown game state {state}");
                }
            }
        }
    }
}
