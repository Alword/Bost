using McAI.Proto.Enum;
using McAI.Proto.Extentions;
using McAI.Proto.Model;
using McAI.Proto.Model.Packet;
using McAI.Proto.Model.Packet.ToServer;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace McAI.BOT
{
    public class Agent
    {

        public delegate void MessageHandler(object sender, byte[] message);
        public event MessageHandler OnRecive;
        private Socket socket;
        private string server;
        private ushort port;
        public Agent(string server, ushort port)
        {
            this.server = server;
            this.port = port;
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(server, port);
        }

        public Task Receive()
        {
            return Task.Run(() =>
            {
                byte[] array = new byte[1024];
                while (socket.Connected)
                {
                    int length = socket.Receive(array);
                    if (length > 0)
                    {
                        OnRecive.Invoke(this, array[0..length]);
                    }
                }
            });
        }

        public async Task Send(BasePacket packet)
        {
            byte[] data = packet.Write();
            List<byte> toSend = new List<byte>();
            toSend.AddRange(Varint.ToBytes(data.Length + 1));
            toSend.AddRange(Varint.ToBytes(0));
            toSend.AddRange(Varint.ToBytes(packet.PacketId));
            toSend.AddRange(data);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var b in toSend)
            {
                stringBuilder.Append($"{b} ");
            }
            Console.WriteLine(stringBuilder.ToString());

            await socket.SendAsync(toSend.ToArray(), SocketFlags.None);
        }

        public async Task Login(string nickname)
        {
            HandshakePacket handshakePacket = new HandshakePacket()
            {
                Address = server,
                LoginState = LoginStates.Login,
                Port = port
            };
            await Send(handshakePacket);

            LoginStartPacket loginStartPacket = new LoginStartPacket
            {
                Name = nickname
            };
            await Send(loginStartPacket);
        }
    }
}
