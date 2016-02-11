using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProApiLibrary.Api.Clients.Responses;
using ProApiLibrary.Api.Responses;
using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Api.Clients.ResponseDecoders.NewtonsoftStreaming
{
	/// <summary>
	/// Copyright 2015 Whitepages, Inc.
	/// </summary>
	public class BusinessResponseDecoder
	{
		public virtual Response<IBusiness> Decode(Stream stream, Client client)
		{
			using (var sr = new StreamReader(stream))
			{
				var json = sr.ReadToEnd();
				var businessResponse = JsonConvert.DeserializeObject<BusinessResponse>(json, new EntityConverter());
				var keys = businessResponse.ResultKeys;
				var list = businessResponse
					.Dictionary
					.Values
					.ToList()
					.Where(x => x.Id.IsBusiness && keys.Contains(x.Id.Key))
					.Select(x => x as IBusiness)
					.ToList();

				var messages = businessResponse.ResponseMessages;
				var dict = new ResponseDictionary(client);
				foreach (var v in businessResponse.Dictionary.Values)
				{
					// this could be any type of base entity.
					v.ResponseDictionary = dict;
					if (v.Id.IsPerson)
					{
						dict.Add(v as IPerson);
					}
					else if (v.Id.IsBusiness)
					{
						dict.Add(v as IBusiness);
					}
					else if (v.Id.IsLocation)
					{
						dict.Add(v as ILocation);
					}
					else if (v.Id.IsPhone)
					{
						dict.Add(v as IPhone);
					}
				}

				foreach (var b in list)
				{
					foreach (var a in b.Associations)
					{
						a.ResponseDictionary = dict;
					}
					
				}

				var response = new Response<IBusiness>(client, list, dict, messages);
				return response;

			}
		} 
	}
}
