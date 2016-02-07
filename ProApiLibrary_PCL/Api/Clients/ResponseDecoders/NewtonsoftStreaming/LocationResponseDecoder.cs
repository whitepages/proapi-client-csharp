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
	public class LocationResponseDecoder
	{
		public virtual Response<ILocation> Decode(Stream stream, Client client)
		{
			using (var sr = new StreamReader(stream))
			{
				var json = sr.ReadToEnd();
				var locationResponse = JsonConvert.DeserializeObject<LocationResponse>(json, new EntityConverter());
				var keys = locationResponse.ResultKeys;
				var list = locationResponse
					.Dictionary
					.Values
					.ToList()
					.Where(x => x.Id.IsLocation && keys.Contains(x.Id.Key))
					.Select(x => x as ILocation)
					.ToList();

				var messages = locationResponse.ResponseMessages;
				var dict = new ResponseDictionary(client);
				foreach (var v in locationResponse.Dictionary.Values)
				{
					v.ResponseDictionary = dict;
					// this could be any type of base entity.
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

				foreach (var loc in list)
				{
					foreach (var a in loc.Associations)
					{	
						a.ResponseDictionary = dict;
					}
				}

				var response = new Response<ILocation>(client, list, dict, messages);
				return response;

			}
		} 
	}
}
