using Bost.Deductions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bost.Deductions.Model
{
	public class Node<T>
	{
		public string Id { get; set; }
		public Colors Color { get; set; }
		public T Value { get; set; }
		public List<T> Incoming { get; set; }
		public List<T> Outgoing { get; set; }
		public Node() { }
		public Node(T Value)
		{
			this.Value = Value;
		}
	}
}
