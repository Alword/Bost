﻿using McAI.Proto.Enum;
using McAI.Proto.Extentions;
using McAI.Proto.Packet;
using McAI.Proto.Packet.Play.Clientbound;
using McAI.Proto.StreamReader.Enum;
using McAI.Proto.StreamReader.Model;
using McAI.Proto.Types;
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
        public Dictionary<(int, ConnectionStates, Bounds), BasePacket> packets;
        public CommandMiddleware(McRequestDelegate _next) : base(_next)
        {
            packets = GetPackets();
        }

        public override void Invoke(McConnectionContext ctx)
        {
            var array = ctx.Data;
            McVarint.TryParse(ref array, out int packetId);
            ctx.PacketId = packetId;
            ctx.Data = array;

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

        public Dictionary<(int, ConnectionStates, Bounds), BasePacket> GetPackets()
        {
            var dictionary = new Dictionary<(int, ConnectionStates, Bounds), BasePacket>();

            var q = (from t in Assembly.GetExecutingAssembly().GetTypes()
                     where t.IsClass && !t.IsAbstract && t.Namespace.StartsWith("McAI.Proto.Packet")
                     select t).ToArray();

            foreach (var t in q)
            {
                var packet = (BasePacket)Activator.CreateInstance(t);


                ConnectionStates connectionState = ConnectionStates.Handshaking;
                Bounds bounds = Bounds.Client;
                if (t.Namespace.Contains("Serverbound"))
                    bounds = Bounds.Server;
                if (t.Namespace.Contains("Packet.Handshaking"))
                    connectionState = ConnectionStates.Handshaking;

                if (t.Namespace.Contains("Packet.Login"))
                    connectionState = ConnectionStates.Login;

                if (t.Namespace.Contains("Packet.Play"))
                    connectionState = ConnectionStates.Play;

                if (t.Namespace.Contains("Packet.Status"))
                    connectionState = ConnectionStates.Status;

                dictionary.Add((packet.PacketId, connectionState, bounds), packet);
            }

            return dictionary;
        }
    }
}
