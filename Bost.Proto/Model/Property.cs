using Bost.Proto.Types;

namespace Bost.Proto.Model
{
	public class Property
	{
		public string Name; //String (32767)
		public string Value; //String (32767)
		public bool IsSigned;
		public string Signature; //Optional String (32767)

		public void Read(ref byte[] array)
		{
			McString.TryParse(ref array, out Name);
			McString.TryParse(ref array, out Value);
			McBoolean.TryParse(ref array, out IsSigned);
			if (IsSigned == true)
			{
				McString.TryParse(ref array, out Signature);
			}
		}

		public override string ToString()
		{
			if (IsSigned == true)
			{
				return $"Name:{Name} Value:{Value} IsSigned:{IsSigned} Signature:{Signature}";
			}
			else
			{
				return $"Name:{Name} Value:{Value} IsSigned:{IsSigned}";
			}
		}
	}
}
