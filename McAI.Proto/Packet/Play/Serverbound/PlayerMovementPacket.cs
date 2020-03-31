using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.ToServer.Play
{
    public class PlayerMovementPacket : BasePacket
    {
        public override int PacketId => 0x14;

        /// <summary>
        /// True if the client is on the ground, false otherwise 
        /// </summary>
        public bool OnGround;

        public override void Read(byte[] array)
        {
            McBoolean.TryParse(ref array, out OnGround);
        }

        public override byte[] Write()
        {
            return McBoolean.ToBytes(OnGround);
        }

        public override string ToString()
        {
            return $">[PlayerMovement|{base.ToString()}] OnGround: {OnGround}";
        }
    }
}
