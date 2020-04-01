using McAI.Proto.StreamReader.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.StreamReader.Middleware
{
    public class CompressionMiddleware : McMiddleware
    {
        public CompressionMiddleware(McRequestDelegate _next) : base(_next)
        {
        }

        public override void Invoke(McConnectionContext mcConnectionContext)
        {
            if (mcConnectionContext.IsCompressed)
            {
                mcConnectionContext.Data = Ionic.Zlib.ZlibStream.UncompressBuffer(mcConnectionContext.Data);
            }
            _next?.Invoke(mcConnectionContext);
        }
    }
}
