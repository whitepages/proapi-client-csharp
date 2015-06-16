using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ProApiLibrary.Data.Entities
{
	[DataContract]
	public class Date
	{
		public Date()
		{
			
		}

		public Date(int year, int month, int day)
		{
			this.Year = year;
			this.Month = month;
			this.Day = day;
		}

		[DataMember(Name="year")]
		public int? Year { get; set; }

		[DataMember(Name="month")]
		public int? Month { get; set; }

		[DataMember(Name="day")]
		public int? Day { get; set; }

		public bool HasValue
		{
			get { return this.Year.HasValue; }
		}

		public DateTime Value
		{
			get { return new System.DateTime(this.Year.Value, this.Month.HasValue ? this.Month.Value : 1, this.Day.HasValue ? this.Day.Value : 1); }
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Date) obj);
		}

		protected bool Equals(Date other)
		{
			return Year == other.Year && Month == other.Month && Day == other.Day;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int hashCode = Year.GetHashCode();
				hashCode = (hashCode * 397) ^ Month.GetHashCode();
				hashCode = (hashCode * 397) ^ Day.GetHashCode();
				return hashCode;
			}
		}

		public static bool operator ==(Date a, Date b)
		{
			if (ReferenceEquals(a, b))
			{
				return true;
			}

			if (((object)a == null) || ((object)b == null))
			{
				return false;
			}

			return a.Year == b.Year && a.Month == b.Month && a.Day == b.Day;
		}
		
		public static bool operator !=(Date a, Date b)
		{
			return !(a == b);
		}

	}
}
