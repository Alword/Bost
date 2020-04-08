﻿using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class EntityTeleportPacket : BasePacket
    {
        public override int PacketId => 0x57;

        public int EntityId;// varint
        public double X;
        public double Y;
        public double Z;
        public byte Yaw;
        public byte Pitch;
        public bool OnGround;

        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out EntityId);
            McDouble.TryParse(ref array, out X);
            McDouble.TryParse(ref array, out Y);
            McDouble.TryParse(ref array, out Z);
            McUnsignedByte.TryParse(ref array, out Yaw);
            McUnsignedByte.TryParse(ref array, out Pitch);
            McBoolean.TryParse(ref array, out OnGround);
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"[EntityTeleport] EntityId: {EntityId} XYZ: {X} {Y} {Z} Yaw: {Yaw} Pitch: {Pitch} OnGround:{OnGround}";
        }
    }
}