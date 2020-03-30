using McAI.Proto.Packet.ToServer.Login;

namespace McAI.Proto.Commands.ToServer.Login
{
    public class LoginStart : Command
    {
        private readonly LoginStartPacket loginStartPacket;
        public LoginStart(bool isLogging = false) : base(isLogging)
        {
            loginStartPacket = new LoginStartPacket();
        }
        public override void Execute(byte[] array)
        {
            loginStartPacket.Read(array);
            Debug($"[Login] {loginStartPacket.Name}");
        }
    }
}
