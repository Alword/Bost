﻿using McAI.Proto.Model;
using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Packet.Play.Clientbound
{
    public class EntityPropertiesPacket : BasePacket
    {
        public override int PacketId => 0x59;

        public int EntityID; //Varint
        public int NumberOfProperties;
        public EntityProperty[] Property;

        public override void Read(byte[] array)
        {
            McVarint.TryParse(ref array, out EntityID);
            McInt.TryParse(ref array, out NumberOfProperties);

            Property = new EntityProperty[NumberOfProperties]; 
            for (int i = 0; i < NumberOfProperties; i++)
            {
                Property[i] = new EntityProperty();
                Property[i].Read(ref array);
            }
        }

        public override byte[] Write()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (Property != null)
            {
                foreach (EntityProperty property in Property)
                {
                    stringBuilder.AppendLine(property.ToString());
                }
            }
            return $"[EntityProperties] EntityID:{EntityID} " +
                $"NumberOfProperties:{NumberOfProperties} Property:{stringBuilder}";
        }
    }
}
