using McAI.Proto.Enum;
using McAI.Proto.Model.ChatObject;
using McAI.Proto.Types;
using System;
using System.Text;

namespace McAI.Proto.Model
{
    public class Player
    {
        public Guid UUID; //UUID

        public string Name; //string(16)
        public int NumberOfProperties; //Varint
        public Property[] Propertys;
        public Gamemods Gamemode; //Varint
        public int Ping; //VarInt
        public bool HasDisplayName;
        public Chat DisplayName; //Optional Chat

        public void Read(ref byte[] array, int action)
        {
            McUUID.TryParse(ref array, out UUID);

            if (action == 0)
            {
                McString.TryParse(ref array, out Name);
                McVarint.TryParse(ref array, out NumberOfProperties);

                Propertys = new Property[NumberOfProperties];
                for (int i = 0; i < NumberOfProperties; i++)
                {
                    Propertys[i] = new Property();
                    Propertys[i].Read(ref array);
                }

                McVarint.TryParse(ref array, out int GamemodeId);
                Gamemode = (Gamemods)GamemodeId;
                McVarint.TryParse(ref array, out Ping);
                McBoolean.TryParse(ref array, out HasDisplayName);
                if (HasDisplayName == true)
                {
                    McChat.TryParse(ref array, out DisplayName);
                }
            }

            if (action == 1)
            {
                McVarint.TryParse(ref array, out int GamemodeId);
                Gamemode = (Gamemods)GamemodeId;
            }

            if (action == 2)
            {
                McVarint.TryParse(ref array, out Ping);
            }

            if (action == 3)
            {
                McBoolean.TryParse(ref array, out HasDisplayName);
                if (HasDisplayName == true)
                {
                    McChat.TryParse(ref array, out DisplayName);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (Propertys != null)
            {
                foreach (Property property in Propertys)
                {
                    stringBuilder.AppendLine(property.ToString());
                }
            }
            return $"UUID:{UUID} Name:{Name} NumberOfProperties:{NumberOfProperties} Propertys:{stringBuilder} " +
                $"Gamemode:{Gamemode} Ping:{Ping} HasDisplayName:{HasDisplayName} " +
                $"DisplayName:{DisplayName}";
        }

    }
}
