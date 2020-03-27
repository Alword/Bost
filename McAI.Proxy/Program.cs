using System;
using System.Text;

namespace McAI.Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ProxyClient proxy = new ProxyClient("0.0.0.0", "95.139.206.185", 25565);
            proxy.Start();
            while (true)
            {
                Console.ReadLine();
                proxy = new ProxyClient("0.0.0.0", "95.139.206.185", 25565);
                proxy.Start();
            }
        }
    }
}
