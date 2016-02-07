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
	public class PersonResponseDecoder
	{
		public virtual Response<IPerson> Decode(Stream stream, Client client)
		{
			using (var sr = new StreamReader(stream))
			{
				var json = sr.ReadToEnd();
				var personResponse = JsonConvert.DeserializeObject<PersonResponse>(json, new EntityConverter());

				// now construct a Response<IPerson> from this
				var keys = personResponse.ResultKeys;
				var list = personResponse
					.Dictionary
					.Values
					.ToList()
					.Where(x=>x.Id.IsPerson && keys.Contains(x.Id.Key))
					.Select(x => x as IPerson)
					.ToList();

				var messages = personResponse.ResponseMessages;
				var dict = new ResponseDictionary(client);
				foreach (var v in personResponse.Dictionary.Values)
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

				foreach (var p in list)
				{
					foreach (var a in p.Associations)
					{
						a.ResponseDictionary = dict;
					}
					if (p.BestLocationAssociation != null)
					{
						p.BestLocationAssociation.ResponseDictionary = dict;
					}
				}

				var response = new Response<IPerson>(client, list, dict, messages);
				return response;

			}
		} 
	}
}
