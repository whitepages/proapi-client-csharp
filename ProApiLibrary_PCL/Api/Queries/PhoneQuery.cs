using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Api.Queries
{
	/// <summary>
	/// The root concrete class for all Phone queries
	/// </summary>
	public class PhoneQuery : EntityQuery
	{
		private PhoneResponseType _responseType = PhoneResponseType.Regular;

		public enum PhoneResponseType
		{
			Regular,
			Lite,
			CallerId
		}

		public PhoneQuery()
		{

		}

		public PhoneQuery(EntityId entityId)
			: base(entityId)
		{

		}

		public PhoneQuery(string phoneNumber)
		{
			this.PhoneNumber = phoneNumber;
		}

		public string PhoneNumber { get; set; }
		public PhoneResponseType ResponseType
		{
			get { return _responseType; }
			set { _responseType = value; }
		}

		public override string ParamsToString()
		{
			return ParamToString("phone", this.PhoneNumber) + ParamToString("responseType", this.ResponseType);
		}
	}
}
