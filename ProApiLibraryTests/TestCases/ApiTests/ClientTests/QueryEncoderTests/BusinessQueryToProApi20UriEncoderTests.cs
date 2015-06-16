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
	public class BusinessQueryToProApi20UriEncoderTests : WhereQueryToProApi20UriEncoderTests<BusinessQuery>
	{
		private const string _uriPath = "/2.0/business.json";
		private const string _name = "Bob's Burgers";
		private const string _nameEncoded = "Bob%27s+Burgers";

		[TestMethod]
		public void NameParameter()
		{
			var uri = this.Encoder.Encode(this.DefaultQuery, this.Client);
			Assert.IsTrue(uri.Query.Contains("name=" + _nameEncoded));
		}
		protected override BusinessQuery DefaultQuery
		{
			get { return new BusinessQuery(_name); }
		}

		protected override IQueryEncoder<BusinessQuery, Uri> Encoder
		{
			get { return new BusinessQueryToProApi20UriEncoder(); }
		}

		protected override string UriPath
		{
			get { return _uriPath; }
		}
	}
}
