using System;
using ProApiLibrary.Api.Clients.DataSources;
using ProApiLibrary.Api.Clients.QueryEncoders;
using ProApiLibrary.Api.Clients.ResponseDecoders;
using ProApiLibrary.Api.Clients.Utils;
using ProApiLibrary.Api.Queries;
using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Api.Clients
{
	/// <summary>
	/// A factory for creation of <seealso cref="IResultFinder"/> instances
	/// </summary>
	/// <remarks>
	/// <p>ResultFinders require choosing a compatible set of <seealso cref="IQueryEncoder"/>, <seealso cref="IDataSource"/>, and
	/// <seealso cref="IResponseDecoder"/> instances in order to function. This factory supplies factory methods for the
	/// creation of properly configured ResultFinder instances.</p>
	/// 
	/// <seealso cref="IResultFinder"/>
	/// </remarks>
	public static class ResultFinderFactory
	{
		public static IResultFinder<IPerson, PersonQuery> DefaultPersonFinder
		{
			get
			{
				return new ResultFinder<IPerson, PersonQuery, HttpResponse, Uri>(new PersonQueryToProApi20UriEncoder(), new HttpDataSource(), new PersonProApi20JsonStreamResponseDecoder());
			}
		}

		public static IResultFinder<IBusiness, BusinessQuery> DefaultBusinessFinder
		{
			get
			{
				return new ResultFinder<IBusiness, BusinessQuery, HttpResponse, Uri>(new BusinessQueryToProApi20UriEncoder(), new HttpDataSource(), new BusinessProApi20JsonStreamResponseDecoder());
			}
		}

		public static IResultFinder<IPhone, PhoneQuery> DefaultPhoneFinder
		{
			get
			{
				return new ResultFinder<IPhone, PhoneQuery, HttpResponse, Uri>(new PhoneQueryToProApi20UriEncoder(), new HttpDataSource(), new PhoneProApi20JsonStreamResponseDecoder());
			}
		}

		public static IResultFinder<ILocation, LocationQuery> DefaultLocationFinder
		{
			get
			{
				return new ResultFinder<ILocation, LocationQuery, HttpResponse, Uri>(new LocationQueryToProApi20UriEncoder(), new HttpDataSource(), new LocationProApi20JsonStreamResponseDecoder());
			}
		}
	}
}
