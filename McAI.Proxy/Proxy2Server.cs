using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace McAI.Proxy
{
    public class Proxy2Server
    {
        public Socket game;
        public Socket server;
        public IPAddress host;
        public int port;
        public bool IsConnected = false;
        public Proxy2Server(string host, int port)
        {
            this.host = IPAddress.Parse(host);
            this.port = port;
            this.server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.server.Connect(host, port);
        }

        public void Start()
        {
            IsConnected = true;
            Task.Run(() =>
            {
                while (IsConnected)
                {
                    var buffer = new byte[256];
                    int size = server.Receive(buffer);
                    if (size > 0)
                    {
                        var toSend = buffer[0..size];
                        //Console.WriteLine($"[<-] {Program.ToHex(toSend)}");
                        game.Send(toSend);
                    }
                }
            });
        }
    }
}
