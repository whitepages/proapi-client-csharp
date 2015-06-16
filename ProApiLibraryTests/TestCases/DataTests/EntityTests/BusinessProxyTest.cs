using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProApiLibraryTests.TestCases.DataTests.EntityTests
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	[TestClass]
	public class BusinessProxyTest
	{
		public ProApiLibrary.Data.Entities.EntityProxy GetProxy()
		{
			return ProxyTestHelper.GetBusinessProxy();
		}

		public ProApiLibrary.Data.Entities.EntityProxy GetProxy(ProApiLibrary.Api.Clients.Client client)
		{
			return ProxyTestHelper.GetBusinessProxy(client);
		}

		public ProApiLibrary.Data.Entities.EntityId ProxyEntityId
		{
			get { return ProxyTestHelper.BusinessId; }
		}

		[TestMethod]
		public void IsLoadedShouldWork()
		{
			var proxy = this.GetProxy();
			Assert.IsFalse(proxy.IsLoaded);
			proxy.Load();
			Assert.IsTrue(proxy.IsLoaded);
		}

		[TestMethod]
		public void LoadFetchesTheEntity()
		{
			var proxy = this.GetProxy();
			proxy.Load();
			Assert.AreEqual(proxy.Id, this.ProxyEntityId);
		}

		[TestMethod]
		public void LoadTwiceShouldNotCauseLookupTwice()
		{
			var client = (ProxyTestHelper.StubClient)ProxyTestHelper.ErrorClient;
			client.ForceErrorResult = false;
			var proxy = GetProxy(client);
			proxy.Load();

			client.ForceErrorResult = true;
			proxy.Load();

		}

		[TestMethod]
		public void LoadingAnEntityNotFoundOnLookup()
		{
			var proxy = GetProxy(ProxyTestHelper.EmptyClient);
			proxy.Load();
			Assert.IsNull(proxy.Entity);
			Assert.IsTrue(proxy.IsLoaded);
		}

	}
}
