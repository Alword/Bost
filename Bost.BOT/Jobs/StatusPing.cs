using Bost.Proto.Enum;
using Bost.Proto.Model;
using Bost.Proto.Packet.Handshaking.Serverbound;
using Bost.Proto.Packet.Status.Clientbound;
using Bost.Proto.Packet.Status.Serverbound;
using Bost.Proto.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bost.Agent.Jobs
{
    public class StatusPing
    {
        private readonly string ip;
        private readonly ushort port;
        public StatusPing(string ip, ushort port)
        {
            this.ip = ip;
            this.port = port;
        }

        public async Task<ServerStatus> RequestStatus()
        {
            var client = new TcpClient();
            var task = client.ConnectAsync(ip, port);

            while (!task.IsCompleted)
            {
                Debug.WriteLine("Connecting..");
                await Task.Delay(250);
            }

            if (!client.Connected)
            {
                return ServerStatus.Empty;
            }

            var stream = client.GetStream();

            var handshake = new HandshakePacket()
            {
                Address = ip,
                Port = port,
                LoginState = LoginStates.Status,
                ProtocolVersion = Program.CurrentProto
            };

            var statusRequest = new Request();

            stream.Write(handshake.Stream());
            stream.Write(statusRequest.Stream());

            var buffer = new byte[Int16.MaxValue];
            stream.Read(buffer, 0, buffer.Length);

            var status = new ResponsePacket();

            try
            {
                McVarint.TryParse(ref buffer, out int length);
                McVarint.TryParse(ref buffer, out int packetId);
                status.Read(buffer);
            }
            catch { }
            return status.GetStatus();
        }
    }
}
