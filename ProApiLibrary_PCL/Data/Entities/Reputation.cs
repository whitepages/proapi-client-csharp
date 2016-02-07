using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ProApiLibrary.Data.Entities
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	[DataContract]
	public class Reputation
	{
		private int? _level;
		private int? _volumeScore;
		private int? _reportCount;

		private IEnumerable<ReputationDetails> _reputationDetails;

		internal Reputation()
		{
			
		}

		[DataMember(Name="level")]
		public int? Level
		{
			get { return _level; }
			set { _level = value; }
		}

		[DataMember(Name = "volume_score")]
		public int? VolumeScore
		{
			get { return _volumeScore; }
			set { _volumeScore = value; }
		}

		[DataMember(Name = "report_count")]
		public int? ReportCount
		{
			get { return _reportCount; }
			set { _reportCount = value; }
		}


		[DataMember(Name="details")]
		public IEnumerable<ReputationDetails> Details
		{
			get { return _reputationDetails ?? (_reputationDetails = new List<ReputationDetails>()); }
			set { _reputationDetails = value; }
		}
	}
}
