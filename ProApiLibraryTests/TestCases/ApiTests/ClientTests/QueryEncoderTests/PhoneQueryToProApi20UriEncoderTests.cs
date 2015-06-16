using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProApiLibrary.Api.Clients;
using ProApiLibrary.Api.Clients.QueryEncoders;
using ProApiLibrary.Api.Queries;

namespace ProApiLibraryTests.TestCases.ApiTests.ClientTests.QueryEncoderTests
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	[TestClass]
	public class PhoneQueryToProApi20UriEncoderTests : QueryToProApi20UriEncoderTests<PhoneQuery>
	{
		private const string _uriPath = "/2.0/phone.json";
		private const string _number = "7075551234";

		[TestMethod]
		public void PhonePropertyPresence()
		{
			var query = new PhoneQuery(_number);
			var uri = this.Encoder.Encode(query, this.Client);
			Assert.IsTrue(uri.Query.Contains("phone_number=" + _number));
		}

		[TestMethod]
		public void ResponsePropertyDefault()
		{
			var query = new PhoneQuery(_number);
			var uri = this.Encoder.Encode(query, this.Client);
			Assert.IsFalse(uri.Query.Contains("response_type="));
		}

		[TestMethod]
		public void ResponsePropertyLite()
		{
			var query = new PhoneLiteQuery(_number);
			var uri = this.Encoder.Encode(query, this.Client);
			Assert.IsTrue(uri.Query.Contains("response_type=lite"));
		}

		protected override PhoneQuery DefaultQuery
		{
			get { return new PhoneQuery(); }
		}

		protected override IQueryEncoder<PhoneQuery, Uri> Encoder
		{
			get { return new PhoneQueryToProApi20UriEncoder(); }
		}

		protected override string UriPath
		{
			get { return _uriPath; }
		}
	}
}
