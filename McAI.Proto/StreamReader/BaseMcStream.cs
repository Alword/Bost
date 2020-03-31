using McAI.Proto.Abstractions;
using McAI.Proto.Enum;
using McAI.Proto.Types;
using System;
using System.Collections.Generic;

namespace McAI.Proto.StreamReader
{
    public class BaseMcStream
    {
        protected int length = 0;
        protected int lengthLength = 0;
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
            while (queue.Count > length + lengthLength)
            {
                array = queue.ToArray();
                McVarint.TryParse(array, out lengthLength, out length);
                if (length + lengthLength > queue.Count) break;

                array = array[lengthLength..(length + lengthLength)];

                queue.RemoveRange(0, length + lengthLength);

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
