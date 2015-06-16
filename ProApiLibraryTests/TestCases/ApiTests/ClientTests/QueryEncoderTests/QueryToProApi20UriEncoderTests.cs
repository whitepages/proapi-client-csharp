using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProApiLibrary.Api.Clients;
using ProApiLibrary.Api.Queries;

namespace ProApiLibraryTests.TestCases.ApiTests.ClientTests.QueryEncoderTests
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	/// <typeparam name="TQ"></typeparam>
	[TestClass]
	public class QueryToProApi20UriEncoderTests<TQ> where TQ : IQuery
	{
		private const string FakeApiKey = "ae9";

		[TestMethod]
		public void NullQuery()
		{
			var obj = default(TQ);
			var uri = this.Encoder.Encode(obj, this.Client);
			Assert.IsFalse(uri == null, "Uri should never be null");
			Assert.IsFalse(String.IsNullOrWhiteSpace(uri.AbsoluteUri), "Uri path should never be null");
			Assert.IsTrue(uri.AbsoluteUri.Contains(this.ServiceRoot), "Uri path should contain service root");
			Assert.IsTrue(uri.AbsoluteUri.Contains("api_key=" + this.ApiKey), "Uri path should contain api key query parameter");
		}

		protected virtual TQ DefaultQuery { get { throw new NotImplementedException("Must override"); } }
		protected virtual IQueryEncoder<TQ, Uri> Encoder { get { throw new NotImplementedException("Must override"); } }
		protected virtual string UriPath { get { throw new NotImplementedException("Must override"); } }

		protected string ServiceRoot
		{
			get { return "http://localhost:8908"; }
		}

		protected Client Client
		{
			get { return new Client(this.Config);}
		}

		private Config Config
		{
			get
			{
				var config = new Config(this.ApiKey) {ServiceRoot = new Uri(this.ServiceRoot)};
				return config;
			}
		}

		private string ApiKey
		{
			get { return FakeApiKey; }
		}
	}
}
