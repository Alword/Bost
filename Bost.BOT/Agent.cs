using Bost.Agent.State;
using Bost.Proto.Enum;
using Bost.Proto.Packet;
using Bost.Proto.Packet.Handshaking.Serverbound;
using Bost.Proto.Packet.Login.Serverbound;
using Bost.Proto.Types;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Bost.Agent
{
    public class Agent
    {
        public delegate void MessageHandler(object sender, byte[] message);

        public event MessageHandler OnRecive;
        public event MessageHandler OnSend;

        public readonly GameState gameState;

        private Socket socket;
        private string server;
        private ushort port;
        public Agent(string server, ushort port)
        {
            this.gameState = new GameState();
            this.server = server;
            this.port = port;
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(server, port);
            StartRecive();
        }

        private Task StartRecive()
        {
            return Task.Run(() =>
            {
                byte[] array = new byte[256];
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

        public async Task Send(byte[] array)
        {
            OnSend?.Invoke(this, array);
            await socket.SendAsync(array, SocketFlags.None);
        }

        public async Task Send(BasePacket basePacket)
        {
            List<byte> toSend = new List<byte>();
            Write(basePacket, true, toSend);
            await Send(toSend.ToArray());
        }

        public async Task Login(string nickname)
        {
            HandshakePacket handshakePacket = new HandshakePacket()
            {
                ProtocolVersion = Program.CurrentProto,
                Address = server,
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
            await Send(toSend.ToArray());
        }

        public void Write(BasePacket packet, bool encrypt = true, List<byte> toSend = null)
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
