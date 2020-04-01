using McAI.Proto.Packet.Login.Clientbound;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Commands.ToClient.Login
{
    public class LoginSuccess : Command
    {
        private readonly LoginSuccessPacket loginSuccessPacket;

        public LoginSuccess(bool isLogging = false) : base(isLogging)
        {
            loginSuccessPacket = new LoginSuccessPacket();
        }

        public override void Execute(byte[] array)
        {
            loginSuccessPacket.Read(array);
            Debug($"[LoginSuccess] UUID:{loginSuccessPacket.UUID} Username:{loginSuccessPacket.Username}");
        }
    }
}
