using McAI.Proto.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace McAI.Proto.Model
{
    public class Property59
    {
        public string Key; //String (64)
        public double Value;
        public int NumberOfModifiers; //Varint 
        public ModifierData[] Modifiers; //Array of Modifier Data

        public void Read(ref byte[] array)
        {
            McString.TryParse(ref array, out Key);
            McDouble.TryParse(ref array, out Value);
            McVarint.TryParse(ref array, out NumberOfModifiers);
            for (int i = 0; i < NumberOfModifiers; i++)
            {
                Modifiers[i] = new ModifierData();
                Modifiers[i].Read(ref array);
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (Modifiers != null)
            {
                foreach (ModifierData modifiers in Modifiers)
                {
                    stringBuilder.AppendLine(modifiers.ToString());
                }
            }
            return $"Key:{Key} Value:{Value} NumberOfModifiers:{NumberOfModifiers} Modifiers:{stringBuilder}";
        }
    }
}
