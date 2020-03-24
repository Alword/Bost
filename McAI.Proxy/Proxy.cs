using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace McAI.Proxy
{
    public class Proxy
    {
        int port;
        string from;
        string to;

        Game2Proxy game2Proxy;
        Proxy2Server proxy2Server;
        public Proxy(string from, string to, int port)
        {
            this.port = port;
            this.from = from;
            this.to = to;
        }

        public void Start()
        {
            Console.WriteLine($"[proxy {from}-{to}] setting up");
            this.game2Proxy = new Game2Proxy(from, port);
            this.game2Proxy.OnDisconection += OnDisconnect;
            this.proxy2Server = new Proxy2Server(to, port);
            Console.WriteLine($"[proxy {from}-{to}] connection established");
            game2Proxy.server = proxy2Server.server;
            proxy2Server.game = game2Proxy.game;
            game2Proxy.Start();
            proxy2Server.Start();
        }

        public void OnDisconnect(object sender, EventArgs e)
        {
            Console.WriteLine("Game client disconected");
            Start();
        }
    }
}
