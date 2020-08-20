using Bost.Proto.Types;
using System;

namespace Bost.Proto.Model
{
    public class ModifierData
    {
        public Guid UUID; //UUID
        public double Amount;
        public sbyte Operation;

        public void Read(ref byte[] array)
        {
            McUUID.TryParse(ref array, out UUID);
            McDouble.TryParse(ref array, out Amount);
            McByte.TryParse(ref array, out Operation);
        }

        public override string ToString()
        {
            return $"UUID:{UUID} Amount:{Amount} Operation:{Operation}";
        }
    }
}
