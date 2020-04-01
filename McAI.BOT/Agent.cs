using McAI.Proto;
using McAI.Proto.Enum;
using McAI.Proto.Extentions;
using McAI.Proto.Packet;
using McAI.Proto.Packet.Handshaking.Serverbound;
using McAI.Proto.Packet.Login.Serverbound;
using McAI.Proto.Types;
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
        private GameState gameState;
        public Agent(string server, ushort port)
        {
            this.gameState = new GameState();
            this.server = server;
            this.port = port;
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(server, port);
            Receive();
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

        public async Task Send(List<byte> toSend, bool encrypt = true)
        {
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
                Address = "0.0.0.0",
                Port = port,
                LoginState = LoginStates.Login,
            };
            List<byte> toSend = new List<byte>();
            Write(handshakePacket, false, toSend);

            LoginStartPacket loginStartPacket = new LoginStartPacket()
            {
                Name = nickname
            };
            Write(loginStartPacket, false, toSend);
            await Send(toSend);
        }

        private void Write(BasePacket packet, bool encrypt = true, List<byte> toSend = null)
        {
            byte[] data = packet.Write();
            if (toSend == null)
            {
                toSend = new List<byte>();
            }

            if (encrypt)
            {
                toSend.AddRange(McVarint.ToBytes(data.Length + 2));
                toSend.AddRange(McVarint.ToBytes(0));
            }
            else
            {
                toSend.AddRange(McVarint.ToBytes(data.Length + 1));
            }

            toSend.AddRange(McVarint.ToBytes(packet.PacketId));
            toSend.AddRange(data);
        }
    }
}
