using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Api.Queries
{
	/// <summary>
	/// The PhoneQuery instance for PhoneLite query construction
	/// </summary>
	public class PhoneLiteQuery : PhoneQuery
	{
		public PhoneLiteQuery()
		{
			this.ResponseType = PhoneResponseType.Lite;
		}

		public PhoneLiteQuery(EntityId entityId) : base(entityId)
		{
			this.ResponseType = PhoneResponseType.Lite;
		}

		public PhoneLiteQuery(string phoneNumber) : base(phoneNumber)
		{
			this.ResponseType = PhoneResponseType.Lite;
		}
	}
}
