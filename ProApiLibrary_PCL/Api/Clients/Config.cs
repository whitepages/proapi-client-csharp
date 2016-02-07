using System;

namespace ProApiLibrary.Api.Clients
{
	/// <summary>
	/// The configuration data class. 
	/// </summary>
	/// <remarks>
	/// <p>In most use cases, appropriate instantiation of the <seealso cref="Client"/> will create an
	/// appropriate configuration. However in some advanced use cases, one or more custom
	/// configurations may be created and configured appropriately.</p>
	/// 
	/// <p>There are several supported idioms for usage of custom configurations, in
	/// order to provide maximum flexibility to our clients. They are:</p>
	/// <ul>
	///     <li>Create a new configuration instance for each client, or</li>
	///     <li>Create a single configuration instance to share beteween many clients.</li>
	/// </ul>
	/// </remarks>
	public class Config
	{
		private readonly Uri _uriDefaultServiceRoot = new Uri("https://proapi.whitepages.com");

		public Config(string apiKey)
		{
			this.ApiKey = apiKey;
			this.ServiceRoot = _uriDefaultServiceRoot;
		}

		public string ApiKey { get; set; }
		public Uri ServiceRoot { get; set; }
	}
}
