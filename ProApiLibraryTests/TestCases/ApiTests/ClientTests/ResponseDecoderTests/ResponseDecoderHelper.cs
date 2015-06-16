using ProApiLibrary.Api.Clients;
using ProApiLibrary.Api.Responses;
using ProApiLibrary.Data.Entities;

namespace ProApiLibraryTests.TestCases.ApiTests.ClientTests.ResponseDecoderTests
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	public class ResponseDecoderHelper
	{
		private readonly static Client Client = new Client("api_key");
		
		private readonly Response<IPerson> _personResponse = DecodePersonResponse();
		private readonly Response<IBusiness> _businessResponse = DecodeBusinessResponse();
		private readonly Response<ILocation> _locationResponse = DecodeLocationResponse();
		private readonly Response<IPhone> _phoneResponse = DecodePhoneResponse();
		private readonly Response<IPhone> _phoneResponse2 = DecodePhoneResponse2();
 
		public Response<IPerson> PersonResponse
		{
			get { return _personResponse; }
		}

		public Response<IBusiness> BusinessResponse
		{
			get { return _businessResponse; }
		}

		public Response<ILocation> LocationResponse
		{
			get { return _locationResponse; }
		}

		public Response<IPhone> PhoneResponse
		{
			get { return _phoneResponse; }
		}

		public Response<IPhone> PhoneResponse2
		{
			get { return _phoneResponse2; }
		}

		private static Response<IPerson> DecodePersonResponse()
		{
			const string PATH = "ProApiLibraryTests.Resources.JsonResponses.personResponse.json";
			using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(PATH))
			{
				var decoder = new ProApiLibrary.Api.Clients.ResponseDecoders.NewtonsoftStreaming.PersonResponseDecoder();
				var response = decoder.Decode(stream, Client);
				return response;

			}
		}

		private static Response<IBusiness> DecodeBusinessResponse()
		{
			const string PATH = "ProApiLibraryTests.Resources.JsonResponses.businessResponse.json";
			using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(PATH))
			{
				var decoder = new ProApiLibrary.Api.Clients.ResponseDecoders.NewtonsoftStreaming.BusinessResponseDecoder();
				var response = decoder.Decode(stream, Client);
				return response;

			}
		}

		private static Response<ILocation> DecodeLocationResponse()
		{
			const string PATH = "ProApiLibraryTests.Resources.JsonResponses.locationResponse.json";
			using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(PATH))
			{
				var decoder = new ProApiLibrary.Api.Clients.ResponseDecoders.NewtonsoftStreaming.LocationResponseDecoder();
				var response = decoder.Decode(stream, Client);
				return response;

			}
		}


		private static Response<IPhone> DecodePhoneResponse()
		{
			const string PATH = "ProApiLibraryTests.Resources.JsonResponses.phoneResponse.json";
			using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(PATH))
			{
				var decoder = new ProApiLibrary.Api.Clients.ResponseDecoders.NewtonsoftStreaming.PhoneResponseDecoder();
				var response = decoder.Decode(stream, Client);
				return response;

			}
		}

		private static Response<IPhone> DecodePhoneResponse2()
		{
			const string PATH = "ProApiLibraryTests.Resources.JsonResponses.phoneResponse2.json";
			using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(PATH))
			{
				var decoder = new ProApiLibrary.Api.Clients.ResponseDecoders.NewtonsoftStreaming.PhoneResponseDecoder();
				var response = decoder.Decode(stream, Client);
				return response;

			}
		}
	}
}
