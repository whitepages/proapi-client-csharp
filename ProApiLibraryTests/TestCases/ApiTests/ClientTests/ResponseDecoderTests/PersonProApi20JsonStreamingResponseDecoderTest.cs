using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProApiLibrary.Api.Responses;
using ProApiLibrary.Data.Associations;
using ProApiLibrary.Data.Entities;

namespace ProApiLibraryTests.TestCases.ApiTests.ClientTests.ResponseDecoderTests
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	[TestClass]
	public class PersonProApi20JsonStreamingResponseDecoderTest
	{
		private static Response<IPerson> _response;
		private static IPerson _person;
		private static LocationAssociation _association;

		[ClassInitialize]
		public static void SetUp(TestContext context)
		{
			/*var resourceNames = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames();
			foreach (var rn in resourceNames)
			{
				Console.Out.WriteLine(rn);
				System.Diagnostics.Debug.WriteLine(rn);
			}*/

			_response = (new ResponseDecoderHelper()).PersonResponse;
			_person = _response.Results.First();
			_association = _person.LocationAssociations.First();
		}


		[TestMethod]
		public void HasResults()
		{
			Assert.AreEqual(23, _response.Results.Count);
		}

		[TestMethod]
		public void HasNames()
		{
			Assert.AreEqual("Janice", _person.Names.First().FirstName);
			Assert.AreEqual(null, _person.Names.First().MiddleName);
			Assert.AreEqual("Smith", _person.Names.First().LastName);
		}

		[TestMethod]
		public void HasLocationAssociations()
		{
			Assert.AreEqual(2, _person.LocationAssociations.Count());
		}

		[TestMethod]
		public void HasLocations()
		{
			Assert.AreEqual(EntityId.FromString("Location.b934db51-65ac-4aec-a72e-7399f853a775.Durable"), _person.Locations.First().Id);
		}

		[TestMethod]
		public void HasPeopleAssociations()
		{
			Assert.IsNull(_person.PersonAssociations);
		}

		[TestMethod]
		public void HasBusinessAssociations()
		{
			Assert.IsNull(_person.BusinessAssociations);
		}

		[TestMethod]
		public void HasAgeRangeStart()
		{
			Assert.AreEqual(55, _person.AgeRange.Start);
		}

		[TestMethod]
		public void HasAgeRangeEnd()
		{
			Assert.AreEqual(59, _person.AgeRange.End);
		}

		[TestMethod]
		public void HasPhoneAssociations()
		{
			Assert.AreEqual(3, _person.PhoneAssociations.Count());
		}

		[TestMethod]
		public void HasBestLocationAssociation()
		{
			Assert.AreEqual(EntityId.FromString("Location.b934db51-65ac-4aec-a72e-7399f853a775.Durable"), _person.BestLocationAssociation.EntityId);
		}

		[TestMethod]
		public void HasExpectedHistoricalAssociationForAttributeTests()
		{
			Assert.AreEqual(EntityId.FromString("Location.b934db51-65ac-4aec-a72e-7399f853a775.Durable"), _association.EntityId);
		}

		[TestMethod]
		public void HasCorrectValidForAssociationAttributes()
		{
			Assert.IsNotNull(_association.ValidFor);
			Assert.AreEqual(new Date(1990, 7, 1), _association.ValidFor.Start);
			Assert.AreEqual(new Date(1990, 12, 1), _association.ValidFor.Stop);
		}

		[TestMethod]
		public void HasCorrectContactCreationDateAssociationAttributes()
		{
			const long TIME_IN_SEC = 1366924661L;
			Assert.IsNotNull(_association.ContactCreationDate);
			var actual = _association.ContactCreationDate.Value;
			var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			var expected = epoch.AddSeconds(TIME_IN_SEC);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void LocationHasLegalEntities()
		{
			var person = _response.Results.First(x => x.Id.Guid.ToString() == "044c0332-c869-4cd3-b957-7e5c9b4e0426");
			var locations = person.Locations.ToList();
			foreach (var location in locations)
			{
				if (location.Id.Guid.ToString() == "fb16064f-d5d9-4236-9d7b-595db318f0b4")
				{
					var legalEntityPerson = location.PersonAssociations.First().Person;
					Assert.AreEqual("044c0332-c869-4cd3-b957-7e5c9b4e0426", legalEntityPerson.Id.Guid.ToString());
				}
			}
			var bestLocation = person.BestLocation;
			var person2 = bestLocation.People.First();
			Assert.AreEqual("1dda652c-6de9-4949-9d1a-b47b203136da", person2.Id.Guid.ToString());
		}
	}
}
