using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace McAI.Proxy
{
    public class Game2Proxy
    {
        public int port;// proxy port
        public IPAddress address; // proxy server
        public Socket socket; // lisnet connection
        public Socket server; // send to server
        public Socket game; // send to game
        public event EventHandler OnDisconection;
        public bool IsConnected;
        public Game2Proxy(string host, int port)
        {
            this.server = null;
            this.port = port;
            this.address = IPAddress.Parse(host);
            this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            socket.Bind(new IPEndPoint(address, port + 1));
            socket.Listen(1);
            game = socket.Accept();
            StartLisnen();
        }

        public void Start()
        {
            IsConnected = true;
            Task.Run(() =>
            {
                while (IsConnected)
                {
                    var buffer = new byte[256];
                    int size = game.Receive(buffer);
                    if (size > 0)
                    {
                        var toSend = buffer[0..size];
                        Console.WriteLine($"[->] {Program.ToHex(toSend)}");
                        server.Send(toSend);
                    }
                }
            });
        }

        public void StartLisnen()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    var newClient = socket.Accept();
                    OnDisconection?.Invoke(this, null);
                }
            });
        }
    }
}
