using McAI.Proto.StreamReader.Enum;
using McAI.Proto.StreamReader.Model;
using System;
using System.Collections.Generic;

namespace McAI.Proto.StreamReader.Middleware
{
    public class StateUpdateMiddleware : McMiddleware
    {
        private readonly Dictionary<(int, ConnectionState, Bounds), Action<McConnectionContext>> rules;
        public StateUpdateMiddleware(McRequestDelegate _next) : base(_next)
        {
            rules = GetRules();
        }

        public override void Invoke(McConnectionContext ctx)
        {
            var key = (ctx.PacketId, ctx.ConnectionState, ctx.BoundTo);

            if (rules.ContainsKey(key))
            {
                rules[key].Invoke(ctx);
            }
            _next?.Invoke(ctx);
        }

        private Dictionary<(int, ConnectionState, Bounds), Action<McConnectionContext>> GetRules()
        {
            return new Dictionary<(int, ConnectionState, Bounds), Action<McConnectionContext>>
            {
                {(0x11,ConnectionState.Handshaking,Bounds.Server),(e)=>e.ConnectionState = ConnectionState.Login },
                {(0x02,ConnectionState.Login,Bounds.Server),(e)=>e.ConnectionState = ConnectionState.Play },
                {(0x00,ConnectionState.Login,Bounds.Server),(e)=>e.IsCompressed = true },

                {(0x03,ConnectionState.Login,Bounds.Client),(e)=>e.IsCompressed = true },
                {(0x02,ConnectionState.Login,Bounds.Client),(e)=>e.ConnectionState = ConnectionState.Play },
            };
        }
    }
}
