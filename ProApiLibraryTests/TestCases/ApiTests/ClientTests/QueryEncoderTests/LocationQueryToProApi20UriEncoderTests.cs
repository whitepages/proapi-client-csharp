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
	public class LocationQueryToProApi20UriEncoderTests : WhereQueryToProApi20UriEncoderTests<LocationQuery>
	{
		private const string _uriPath = "/2.0/location.json";

		protected override LocationQuery DefaultQuery
		{
			get { return new LocationQuery(); }
		}

		protected override IQueryEncoder<LocationQuery, Uri> Encoder
		{
			get { return new LocationQueryToProApi20UriEncoder(); }
		}

		protected override string UriPath
		{
			get { return _uriPath; }
		}
	}
}
