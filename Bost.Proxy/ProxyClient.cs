using System;

namespace Bost.Proxy
{
    public class ProxyClient
    {
        public delegate void MessageHandler(object sender, byte[] message);

        public event MessageHandler OnSendMessage
        {
            add
            {
                game2Proxy.OnSendMessage += value;
            }
            remove
            {
                game2Proxy.OnSendMessage -= value;
            }
        }

        public event MessageHandler OnReciveMessage
        {
            add
            {
                proxy2Server.OnReciveMessage += value;
            }
            remove
            {
                proxy2Server.OnReciveMessage -= value;
            }
        }

        private int port;
        private string from;
        private string to;

        private Game2Proxy game2Proxy;
        private Proxy2Server proxy2Server;
        public ProxyClient(string from, string to, int port)
        {
            this.port = port;
            this.from = from;
            this.to = to;
        }

        public void Start()
        {
            Console.WriteLine($"[proxy {from}-{to}] setting up");
            this.game2Proxy = new Game2Proxy(from, port);
            this.proxy2Server = new Proxy2Server(to, port);
            Console.WriteLine($"[proxy {from}-{to}] connection established");
            game2Proxy.server = proxy2Server.server;
            proxy2Server.game = game2Proxy.game;
            game2Proxy.Start();
            proxy2Server.Start();
        }
    }
}
