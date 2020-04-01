using McAI.Proto.Enum;
using McAI.Proto.Extentions;
using McAI.Proto.Packet;
using McAI.Proto.Packet.Play.Clientbound;
using McAI.Proto.StreamReader.Enum;
using McAI.Proto.StreamReader.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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
            else
            {
                Program.Log($"{ctx.PacketId} | {ctx.ConnectionState} | {ctx.BoundTo} | {ctx.Data.ToHexString()}");
            }
            _next?.Invoke(ctx);
        }

        public Dictionary<(int, ConnectionState, Bounds), BasePacket> GetPackets()
        {
            var dictionary = new Dictionary<(int, ConnectionState, Bounds), BasePacket>();

            var q = (from t in Assembly.GetExecutingAssembly().GetTypes()
                     where t.IsClass && !t.IsAbstract && t.Namespace.StartsWith("McAI.Proto.Packet")
                     select t).ToArray();

            foreach (var t in q)
            {
                var packet = (BasePacket)Activator.CreateInstance(t);


                ConnectionState connectionState = ConnectionState.Handshaking;
                Bounds bounds = Bounds.Client;
                if (t.Namespace.Contains("Serverbound"))
                    bounds = Bounds.Server;
                if (t.Namespace.Contains("Packet.Handshaking"))
                    connectionState = ConnectionState.Handshaking;

                if (t.Namespace.Contains("Packet.Login"))
                    connectionState = ConnectionState.Login;

                if (t.Namespace.Contains("Packet.Play"))
                    connectionState = ConnectionState.Play;

                if (t.Namespace.Contains("Packet.Status"))
                    connectionState = ConnectionState.Status;

                dictionary.Add((packet.PacketId, connectionState, bounds), packet);
            }

            return dictionary;
        }
    }
}
