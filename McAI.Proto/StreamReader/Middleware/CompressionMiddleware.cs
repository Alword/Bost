using Bost.Proto.StreamReader.Model;
using Bost.Proto.Types;

namespace Bost.Proto.StreamReader.Middleware
{
    public class CompressionMiddleware : McMiddleware
    {
        public CompressionMiddleware(McRequestDelegate _next) : base(_next)
        {
        }

        public override void Invoke(McConnectionContext ctx)
        {
            if (ctx.IsCompressed)
            {
                var array = ctx.Data;
                McVarint.TryParse(ref array, out int compressedLength);
                ctx.CompressionLength = compressedLength;

                if (ctx.CompressionLength > 0)
                {
                    array = Ionic.Zlib.ZlibStream.UncompressBuffer(array);
                }
                ctx.Data = array;
            }
            _next?.Invoke(ctx);
        }
    }
}
