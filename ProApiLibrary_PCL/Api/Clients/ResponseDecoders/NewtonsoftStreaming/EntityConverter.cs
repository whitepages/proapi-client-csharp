using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Api.Clients.ResponseDecoders.NewtonsoftStreaming
{
	/// <summary>
	/// Copyright 2015 Whitepages, Inc.
	/// </summary>
	public class EntityConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var jo = JObject.Load(reader);
			var id = jo["id"];
			var key = id["key"].ToString();

			IEntity ret = null;
			if (key.StartsWith("Person"))
			{
				ret = new Person();
				serializer.Populate(jo.CreateReader(), ret);
			}
			else if (key.StartsWith("Location"))
			{
				ret = new Location();
				serializer.Populate(jo.CreateReader(), ret);
			}
			else if (key.StartsWith("Phone"))
			{
				ret = new Phone();
				serializer.Populate(jo.CreateReader(), ret);
			}
			else if (key.StartsWith("Business"))
			{
				ret = new Business();
				serializer.Populate(jo.CreateReader(), ret);
			}
			return ret;
			
		}

		public override bool CanConvert(Type objectType)
		{
			return (typeof (BaseEntity)).IsAssignableFrom(objectType);
		}
	}
}
