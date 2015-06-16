using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProApiLibrary.Data.Entities
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	[DataContract]
	public class TimePeriod
	{
		[DataMember(Name="start")]
		public ProApiLibrary.Data.Entities.Date Start { get; set; }
		[DataMember(Name="stop")]
		public ProApiLibrary.Data.Entities.Date Stop { get; set; }
		[DataMember(Name="is_historical")]
		public bool IsHistorical { get; set; }
		public bool IsCurrent
		{
			get { return !IsHistorical; }
		}

		public override string ToString()
		{
			return String.Format("TimePeriod{{start={0},stop={1}}}",
				this.Start.HasValue ? this.Start.Value.ToString("MM/dd/yyyy") : "null",
				this.Stop.HasValue ? this.Stop.Value.ToString("MM/dd/yyyy") : "null");
		}
	}
}
