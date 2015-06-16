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
	public class Reputation
	{
		private int? _spamScore;

		internal Reputation()
		{
			
		}

		public Reputation(int spamScore)
		{
			_spamScore = spamScore;
		}

		[DataMember(Name="spam_score")]
		public int? SpamScore
		{
			get { return _spamScore; }
			set { _spamScore = value; }
		}
	}
}
