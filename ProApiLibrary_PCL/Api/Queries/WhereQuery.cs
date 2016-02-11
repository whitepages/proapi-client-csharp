using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Api.Queries
{
	/// <summary>
	/// An abstract superclass for all queries that can specify "where" parameters
	/// </summary>
	public abstract class WhereQuery : EntityQuery
	{
		protected WhereQuery()
		{
			
		}

		protected WhereQuery(EntityId entityId) : base(entityId)
		{
			
		}

		protected WhereQuery(string streetLine1, string streetLine2, string city, string stateCode, string postalCode)
		{
			this.StreetLine1 = streetLine1;
			this.StreetLine2 = streetLine2;
			this.City = city;
			this.StateCode = stateCode;
			this.PostalCode = postalCode;
		}

		protected WhereQuery(string city, string stateCode, string postalCode)
		{
			this.City = city;
			this.StateCode = stateCode;
			this.PostalCode = postalCode;
		}

		protected WhereQuery(double latitude, double longitude, double radius)
		{
			this.Latitude = latitude;
			this.Longitude = longitude;
			this.Radius = radius;
		}

		public string StreetLine1 { get; set; }
		public string StreetLine2 { get; set; }
		public string City { get; set; }
		public string StateCode { get; set; }
		public string PostalCode { get; set; }
		public string CountryCode { get; set; }
		public double? Latitude { get; set; }
		public double? Longitude { get; set; }
		public double? Radius { get; set; }


		public override string ParamsToString()
		{
			return String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}",
			                     ParamToString("streetLine1", this.StreetLine1),
			                     ParamToString("streetLine2", this.StreetLine2),
			                     ParamToString("city", this.City),
			                     ParamToString("stateCode", this.StateCode),
			                     ParamToString("postalCode", this.PostalCode),
			                     ParamToString("countryCode", this.CountryCode),
			                     ParamToString("latitude", this.Latitude),
			                     ParamToString("longitude", this.Longitude),
			                     ParamToString("radius", this.Radius));


		}
	}
}
