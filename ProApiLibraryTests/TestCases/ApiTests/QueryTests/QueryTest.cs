using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProApiLibrary.Api.Queries;

namespace ProApiLibraryTests.TestCases.ApiTests.QueryTests
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	[TestClass]
	public class QueryTest
	{
		[TestMethod]
		public void ItShouldPrintAHumanReadablePersonQuery()
		{
			var q = new PersonQuery("Amelia", "Jessica", "Pond", "Seattle", "WA", "98101");

			var s = q.ToString();
			Console.Out.WriteLine(s);

			Assert.IsTrue(s.StartsWith("PersonQuery"));
			Assert.IsTrue(s.Contains("Amelia"));
			Assert.IsTrue(s.Contains("Jessica"));
			Assert.IsTrue(s.Contains("Pond"));
			Assert.IsTrue(s.Contains("Seattle"));
			Assert.IsTrue(s.Contains("WA"));
			Assert.IsTrue(s.Contains("98101"));
		}

		[TestMethod]
		public void ItShouldPrintAHumanReadableBusinessQuery()
		{
			var q = new BusinessQuery("Whitepages") {City = "Seattle", StateCode = "WA"};

			var s = q.ToString();
			Console.Out.WriteLine(s);

			Assert.IsTrue(s.StartsWith("BusinessQuery"));
			Assert.IsTrue(s.Contains("Whitepages"));
			Assert.IsTrue(s.Contains("Seattle"));
			Assert.IsTrue(s.Contains("WA"));

		}

		[TestMethod]
		public void ItShouldPrintAHumanReadablePhoneQuery()
		{
			var q = new PhoneQuery("2065551234");

			var s = q.ToString();
			Console.Out.WriteLine(s);

			Assert.IsTrue(s.StartsWith("PhoneQuery"));
			Assert.IsTrue(s.Contains("2065551234"));
		}

		[TestMethod]
		public void ItShouldPrintAHumanReadableLocationQuery()
		{
			var q = new LocationQuery("1301 5th Ave", "Ste 1600", "Seattle", "WA", "98101");

			var s = q.ToString();
			Console.Out.WriteLine(s);

			Assert.IsTrue(s.StartsWith("LocationQuery"));
			Assert.IsTrue(s.Contains("1301 5th Ave"));Assert.IsTrue(s.Contains("Ste 1600"));
			Assert.IsTrue(s.Contains("Seattle"));
			Assert.IsTrue(s.Contains("WA"));
			Assert.IsTrue(s.Contains("98101"));

		}


	}
}
