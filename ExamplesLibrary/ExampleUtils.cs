using System;
using System.Linq;
using ProApiLibrary.Data.Associations;
using ProApiLibrary.Data.Entities;

namespace ExamplesLibrary
{
	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	public class ExampleUtils
	{
		private const int DefaultIndent = 4;

		public static string GetApiKey(string[] args)
		{
			if (args.Length != 1)
			{
				// try to get the api key from the config file
				var apiKey = System.Configuration.ConfigurationManager.AppSettings["api_key"];
				if (!String.IsNullOrWhiteSpace(apiKey))
				{
					return apiKey;
				}

				throw new Exception("Please provide an API key either as the first argument to this program, or in a config value with the key 'api_key'.");
			}
			return args[0];
		}

		public static void DumpPerson(IPerson person, int depth, int indent = 0)
		{
			PrintName(person, indent);

			WriteLine(indent, "Best Name:                   {0}", person.BestName);
			WriteLine(indent, "Names:                       {0}", String.Join(", ", person.Names));
			WriteLine(indent, "Age Range:                   {0}", person.AgeRange);
			WriteLine(indent, "Gender:                      {0}", person.Gender);
			WriteLine(indent, "Type:                        {0}", person.Type);

			BestLocation(person.BestLocation, depth, indent);

			DumpBaseEntity(person, depth, indent);
		}

		public static void DumpBusiness(IBusiness business, int depth, int indent = 0)
		{
			PrintName(business, indent);
			DumpBaseEntity(business, depth, indent);
		}

		public static void DumpLocation(ILocation location, int depth, int indent = 0)
		{
			PrintName(location, indent);
			WriteLine(indent, "Address:                     {0}", location.Address);

			WriteLine(indent, "Address Type:                {0}", location.AddressType);
			WriteLine(indent, "Apartment Number:            {0}", location.AptNumber);
			WriteLine(indent, "Box Number:                  {0}", location.BoxNumber);
			WriteLine(indent, "City:                        {0}", location.City);
			WriteLine(indent, "CountryCode:                 {0}", location.CountryCode);
			WriteLine(indent, "Deliverable:                 {0}", location.IsDeliverable);
			WriteLine(indent, "Delivery Point:              {0}", location.DeliveryPoint);
			WriteLine(indent, "House:                       {0}", location.House);
			WriteLine(indent, "Latitude/Longitude:          {0}", location.LatLong);
			WriteLine(indent, "Not Receiving Mail Reason:   {0}", location.NotReceivingMailReason);
			WriteLine(indent, "Postal Code:                 {0}", location.PostalCode);
			WriteLine(indent, "Post Directional:            {0}", location.PostDir);
			WriteLine(indent, "Pre Directional:             {0}", location.PreDir);
			WriteLine(indent, "Receiving Mail:              {0}", location.IsReceivingMail);
			WriteLine(indent, "Standard Address Line1:      {0}", location.StandardAddressLine1);
			WriteLine(indent, "Standard Address Line2:      {0}", location.StandardAddressLine2);
			WriteLine(indent, "Standard Address Location:   {0}", location.StandardAddressLocation);
			WriteLine(indent, "State Code:                  {0}", location.StateCode);
			WriteLine(indent, "Street Name:                 {0}", location.StreetName);
			WriteLine(indent, "Street Type:                 {0}", location.StreetType);
			WriteLine(indent, "Usage:                       {0}", location.Usage);
			WriteLine(indent, "ValidFor:                    {0}", location.ValidFor);
			WriteLine(indent, "Zip4:                        {0}", location.Zip4);

			DumpBaseEntity(location, depth, indent);
		}

		public static void DumpPhone(IPhone phone, int depth, int indent = 0)
		{
			PrintName(phone, indent);
			WriteLine(indent, "Carrier:                     {0}", phone.Carrier);
			WriteLine(indent, "Country Calling Code:        {0}", phone.CountryCallingCode);
			WriteLine(indent, "Do Not Call:                 {0}", phone.DoNotCall);
			WriteLine(indent, "Extension:                   {0}", phone.Extension);
			WriteLine(indent, "LineType:                    {0}", phone.LineType);
			WriteLine(indent, "PhoneNumber:                 {0}", phone.PhoneNumber);
			WriteLine(indent, "Is Prepaid:                  {0}", phone.IsPrepaid);
			WriteLine(indent, "Reputation:                  {0}", GetSpamScore(phone));
			WriteLine(indent, "Is Valid:                    {0}", phone.IsValid);

			BestLocation(phone.BestLocation, depth, indent);

			DumpBaseEntity(phone, depth, indent);
			
		}

		#region Helper Methods

		private static int? GetSpamScore(IPhone phone)
		{
			return Phone.GetSpamScore(phone.Reputation);
		}

		private static void BestLocation(ILocation location, int depth, int indent)
		{
			if (depth > 1 && location != null)
			{
				WriteLine(indent, "Best Location: {0,15}", location.Name);
			}
		}

		#endregion

		#region Formatting / Printing Methods

		private static void DumpBaseEntity(IEntity entity, int depth, int indent)
		{
			if (depth > 1)
			{
				var businesses = entity.BusinessAssociations;
				if (businesses != null)
				{
					var list = businesses.ToList();
					if (list.Any())
					{
						WriteLine(indent, "Businesses:");
						foreach (var business in list)
						{
							DumpBusinessAssociation(business, depth - 1, indent + DefaultIndent);
							Console.Out.WriteLine();
						}
					}
				}

				var locations = entity.LocationAssociations;
				if (locations != null)
				{
					var list = locations.ToList();
					if (list.Any())
					{
						WriteLine(indent, "Locations:");
						foreach (var location in list)
						{
							DumpLocationAssociation(location, depth - 1, indent + DefaultIndent);
							Console.Out.WriteLine();
						}
					}
				}

				var people = entity.PersonAssociations;
				if (people != null)
				{
					var list = people.ToList();
					if (list.Any())
					{
						WriteLine(indent, "People:");
						foreach (var person in list)
						{
							DumpPersonAssociation(person, depth - 1, indent + DefaultIndent);
							Console.Out.WriteLine();
						}
					}
				}

				var phones = entity.PhoneAssociations;
				if ((phones != null))
				{
					var list = phones.ToList();
					if (list.Any())
					{
						WriteLine(indent, "Phones:");
						foreach (var phone in list)
						{
							DumpPhoneAssociation(phone, depth - 1, indent + DefaultIndent);
							Console.Out.WriteLine();
						}
					}
				}
			}
		}

		private static void DumpPersonAssociation(PersonAssociation association, int depth, int indent)
		{
			DumpPerson(association.Person, depth, indent);
		}

		private static void DumpBusinessAssociation(BusinessAssociation association, int depth, int indent)
		{
			DumpBusiness(association.Business, depth, indent);
		}

		private static void DumpLocationAssociation(LocationAssociation association, int depth, int indent)
		{
			WriteLine(indent, "Contact Type:                {0}", association.ContactType);
			WriteLine(indent, "Location:");
			DumpLocation(association.Location, depth, indent + DefaultIndent);
		}

		private static void DumpPhoneAssociation(PhoneAssociation association, int depth, int indent)
		{
			WriteLine(indent, "Contact Type:                {0}", association.ContactType);
			WriteLine(indent, "Phone:");
			DumpPhone(association.Phone, depth, indent + DefaultIndent);

		}


		private static void PrintName(IEntity entity, int indent)
		{
			WriteLine(indent, "Name:{0,24}", entity.Name);
		}

		private static void WriteLine(int indent, string format, Object value = null)
		{
			Indent(indent);
			Console.WriteLine(format, value);
		}

		private static void Indent(int howMany)
		{
			for (var i = 0; i < howMany; i++)
			{
				Console.Out.Write(" ");
			}
		}

		#endregion

	}

}
