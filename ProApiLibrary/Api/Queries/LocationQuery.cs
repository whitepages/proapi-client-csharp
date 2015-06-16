using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Api.Queries
{
	/// <summary>
	/// The root concrete class for all Location queries
	/// </summary>
	public class LocationQuery : WhereQuery
	{
		public LocationQuery()
		{
			
		}

		public LocationQuery(EntityId entityId)
			: base(entityId)
		{
			
		}

		public LocationQuery(string streetLine1, string streetLine2, string city, string stateCode, string postalCode)
			: base(streetLine1, streetLine2, city, stateCode, postalCode)
		{
			
		}

		public LocationQuery(double latitude, double longitude, double radius)
			: base(latitude, longitude, radius)
		{
			
		}
	}
}
