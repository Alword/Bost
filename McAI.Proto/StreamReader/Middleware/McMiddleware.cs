using McAI.Proto.StreamReader.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.StreamReader
{
    public abstract class McMiddleware
    {
        public delegate void McRequestDelegate(McConnectionContext mcConnectionContext);

        protected readonly McRequestDelegate _next;

        public McMiddleware(McRequestDelegate _next)
        {

        }

        public abstract void Invoke(McConnectionContext mcConnectionContext);
    }
}
