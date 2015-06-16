using System;
using System.Runtime.Serialization;

namespace ProApiLibrary.Data.Entities
{
	[DataContract]
	public class AgeRange
	{
		[DataMember(Name="start")]
		public int Start { get; set; }
		
		[DataMember(Name="end")]
		public int End { get; set; }
		
		public override string ToString()
		{
			return String.Format("AgeRange{{start={0}, end={1}}}", this.Start, this.End);
		}
	}
}
