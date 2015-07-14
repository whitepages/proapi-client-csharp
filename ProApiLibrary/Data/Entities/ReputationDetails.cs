using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProApiLibrary.Data.Entities
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	[DataContract]
	public class ReputationDetails
	{
		private int? _score;
		private string _type;
		private string _category;

		internal ReputationDetails()
		{
			
		}

		[DataMember(Name="score")]
		public int? Score
		{
			get { return _score; }
			set { _score = value; }
		}

		[DataMember(Name="type")]
		public string TypeValue
		{
			get { return _type; }
			set { _type = value; }
		}

		[DataMember(Name="category")]
		public string Category
		{
			get { return _category; }
			set { _category = value; }
		}
	}
}
