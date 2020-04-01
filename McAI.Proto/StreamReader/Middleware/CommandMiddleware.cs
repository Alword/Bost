using McAI.Proto.Enum;
using McAI.Proto.Packet;
using McAI.Proto.Packet.Play.Clientbound;
using McAI.Proto.StreamReader.Enum;
using McAI.Proto.StreamReader.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace McAI.Proto.StreamReader.Middleware
{
    public class CommandMiddleware : McMiddleware
    {
        public Dictionary<(int, ConnectionState, Bounds), BasePacket> packets;
        public CommandMiddleware(McRequestDelegate _next) : base(_next)
        {
        }

        public override void Invoke(McConnectionContext ctx)
        {
            var key = (ctx.PacketId, ctx.ConnectionState, ctx.BoundTo);
            if (packets.ContainsKey(key))
            {
                var packet = packets[key];
                packet.Read(ctx.Data);
                Program.Log($"{ctx.PacketId} | {ctx.ConnectionState} | {ctx.BoundTo} | {packet}");
            }
            _next?.Invoke(ctx);
        }

        public Dictionary<(int, ConnectionState, Bounds), BasePacket> GetPackets()
        {
            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == ""
                    select t;

            return new Dictionary<(int, ConnectionState, Bounds), BasePacket>
            {
                {(1,ConnectionState.Handshaking,Bounds.Client),new ChunkDataPacket()},
            };
        }
    }
}
