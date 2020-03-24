using System;
using System.Text;

namespace McAI.Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Proxy proxy = new Proxy("0.0.0.0", "192.168.1.69", 25565);
            proxy.Start();
            while (true)
            {
                Console.ReadLine();
                proxy.OnDisconnect(null, null);
            }
        }

        public static string ToHex(byte[] ba)
        {
            StringBuilder sb = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                sb.AppendFormat("{0:x2}", b);
            }
            return sb.ToString();
        }
    }
}
