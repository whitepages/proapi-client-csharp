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
	public class PersonQueryToProApi20UriEncoderTests : WhereQueryToProApi20UriEncoderTests<PersonQuery>
	{
		private static string _uriPath = "/2.0/person.json";

		private static string _name = "Amelia Pond";
		private static string _nameEncoded = "Amelia+Pond";
		private static string _firstName = "Amelia";
		private static string _middleName = "Jessica";
		private static string _lastName = "Pond";
		private static string _suffix = "I";
		private static string _title = "Dr";

		[TestMethod]
		public void NameParameter()
		{
			var uri = this.Encoder.Encode(FullNameQuery, Client);
			Assert.IsTrue(uri.AbsoluteUri.Contains("name=" + _nameEncoded));
		}

		[TestMethod]
		public void FirstNameParameter()
		{
			var uri = this.Encoder.Encode(DefaultQuery, Client);
			Assert.IsTrue(uri.AbsoluteUri.Contains("first_name=" + _firstName));
		}

		[TestMethod]
		public void MiddleNameParameter()
		{
			var uri = this.Encoder.Encode(DefaultQuery, Client);
			Assert.IsTrue(uri.AbsoluteUri.Contains("middle_name=" + _middleName));
		}

		[TestMethod]
		public void LastNameParameter()
		{
			var uri = this.Encoder.Encode(DefaultQuery, Client);
			Assert.IsTrue(uri.AbsoluteUri.Contains("last_name=" + _lastName));
		}

		[TestMethod]
		public void TitleParameter()
		{
			var uri = this.Encoder.Encode(TitleAndSuffixNameQuery, Client);
			Assert.IsTrue(uri.AbsoluteUri.Contains("title=" + _title));
		}

		[TestMethod]
		public void SuffixParameter()
		{
			var uri = this.Encoder.Encode(TitleAndSuffixNameQuery, Client);
			Assert.IsTrue(uri.AbsoluteUri.Contains("suffix=" + _suffix));
		}

		[TestMethod]
		public void NamePartParametersOptional()
		{
			var uri = this.Encoder.Encode(FullNameQuery, Client);
			Assert.IsFalse(uri.AbsoluteUri.Contains("first_name"));
			Assert.IsFalse(uri.AbsoluteUri.Contains("middle_name"));
			Assert.IsFalse(uri.AbsoluteUri.Contains("last_name"));
		}

		[TestMethod]
		public void TitleParametersOptional()
		{
			var uri = this.Encoder.Encode(DefaultQuery, Client);
			Assert.IsFalse(uri.AbsoluteUri.Contains("title"));
			Assert.IsFalse(uri.AbsoluteUri.Contains("suffix"));
		}

		[TestMethod]
		public void BooleanProperties()
		{
			var uri = this.Encoder.Encode(BooleanTestingQuery, Client);
			Assert.IsFalse(uri.AbsoluteUri.Contains("use_metro"));
			Assert.IsTrue(uri.AbsoluteUri.Contains("use_historical=false"));
		}

		protected PersonQuery TitleAndSuffixNameQuery
		{
			get
			{
				var query = DefaultQuery;
				query.Suffix = _suffix;
				query.Title = _title;
				return query;
			}
		}

		protected PersonQuery BooleanTestingQuery
		{
			get
			{
				var query = DefaultQuery;
				query.UseHistorical = false;
				query.UseMetro = null;
				return query;
			}
		}

		protected PersonQuery FullNameQuery
		{
			get
			{
				return new PersonQuery(_name, null, null, null);
			}
		}

		protected override PersonQuery DefaultQuery
		{
			get
			{
				return new PersonQuery(_firstName, _middleName, _lastName, null, null, null);
			}
		}

		protected override IQueryEncoder<PersonQuery, Uri> Encoder
		{
			get { return new PersonQueryToProApi20UriEncoder(); }
		}

		protected override string UriPath
		{
			get { return _uriPath; }
		}
	}
}
