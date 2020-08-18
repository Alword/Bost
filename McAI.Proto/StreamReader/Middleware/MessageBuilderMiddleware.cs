using Bost.Proto.StreamReader.Model;
using Bost.Proto.Types;
using System.Collections.Generic;
using System.Diagnostics;

namespace Bost.Proto.StreamReader.Middleware
{
    public class MessageBuilderMiddleware : McMiddleware
    {
        protected int length = 0;
        protected int lengthLength = 0;
        protected List<byte> queue = new List<byte>();

        public MessageBuilderMiddleware(McRequestDelegate _next) : base(_next)
        {
        }

        public override void Invoke(McConnectionContext ctx)
        {
            queue.AddRange(ctx.Data);
            while (queue.Count > 0)
            {
                ctx.Data = queue.ToArray();

                bool parsed = McVarint.TryParse(ctx.Data, out lengthLength, out length);

                if (!parsed)
                {
                    Debug.WriteLine("Packet is too small, read next packet");
                    break;
                }

                if (length + lengthLength > queue.Count) break;

                ctx.Data = ctx.Data[lengthLength..(length + lengthLength)];
                queue.RemoveRange(0, length + lengthLength);

                ctx.Length = length;
                _next?.Invoke(ctx);
            }
        }
    }
}
