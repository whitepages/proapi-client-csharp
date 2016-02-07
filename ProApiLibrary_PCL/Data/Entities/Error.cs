using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProApiLibrary.Data.Entities
{
	[DataContract]
	public class Error
	{
		[DataMember(Name="name")]
		public string Name { get; set; }

		[DataMember(Name="message")]
		public string Message { get; set; }
	}
}
