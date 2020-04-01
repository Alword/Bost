using McAI.Proto.StreamReader.Model;
using McAI.Proto.Types;
using System;
using System.Collections.Generic;

namespace McAI.Proto.StreamReader.Middleware
{
    public class MessageBuilderMiddleware : McMiddleware
    {
        protected int length = 0;
        protected int lengthLength = 0;
        protected List<byte> queue = new List<byte>();

        public MessageBuilderMiddleware(McRequestDelegate _next) : base(_next)
        {
        }

        public override void Invoke(McConnectionContext mcConnectionContext)
        {
            var array = mcConnectionContext.Data;
            queue.AddRange(array);
            while (queue.Count > 0)
            {
                array = queue.ToArray();
                McVarint.TryParse(array, out lengthLength, out length);
                if (length + lengthLength > queue.Count) break;
                array = array[lengthLength..(length + lengthLength)];
                queue.RemoveRange(0, length + lengthLength);

                mcConnectionContext.Length = length;
                mcConnectionContext.Data = array;
                _next?.Invoke(mcConnectionContext);
            }
        }
    }
}
