using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ProApiLibrary.Data.Entities
{
	/// <summary>
	/// The data class encapsulating <seealso cref="IEntity"/> IDs.
	/// </summary>
	/// <remarks>
	/// In addition to being used as an opaque ID, this class
	/// presents methods for extracting metadata about the ID.
	/// 
	/// <seealso cref="IEntity"/>
	/// </remarks>
	[DataContract]
	public class EntityId
	{
		public enum EntityType
		{
			Person,
			Business,
			Location,
			Phone,
		}

		public EntityId(EntityType type, Guid guid, Durability durability)
		{
			this.Type = type;
			this.Guid = guid;
			this.Durability = durability;
		}

		[DataMember(Name = "key")]
		public string Key { get; set; }

		[DataMember(Name = "type")]
		public EntityType Type { get; set; }

		[DataMember(Name = "uuid")]
		public Guid Guid { get; set; }

		[DataMember(Name = "durability")]
		public Durability Durability { get; set; }

		public static EntityId FromString(string key)
		{
			var pieces = key.Split(new[] { '.' });
			if (pieces.Length != 3)
			{
				throw new ArgumentException(@"EntityId string expected to be in format ""<type>.<uuid>.<durability>""");
			}
			var entityType = (EntityType)Enum.Parse(typeof(EntityType), pieces[0], true);
			var guid = new Guid(pieces[1]);
			var durability = (Durability)Enum.Parse(typeof(Durability), pieces[2], true);

			return new EntityId(entityType, guid, durability)
				{
					Key = key
				};
		}

		public bool Equals(EntityId id)
		{
			if (this == id)
			{
				return true;
			}
			if ((id == null) || this.GetType() != id.GetType())
			{
				return false;
			}

			if ((this.Type != id.Type) || (this.Guid != id.Guid))
			{
				return false;
			}

			return true;

		}

		public override int GetHashCode()
		{
			var result = this.Type.GetHashCode();
			result = 31 * result + this.Guid.GetHashCode();
			return result;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}

			var other = obj as EntityId;
			if (other == null)
			{
				return false;
			}

			return (other.Type == this.Type && other.Guid == this.Guid);
		}

		public static bool operator ==(EntityId a, EntityId b)
		{
			if (ReferenceEquals(a, b))
			{
				return true;
			}

			if (((object)a == null) || ((object)b == null))
			{
				return false;
			}

			return a.Type == b.Type && a.Guid == b.Guid;
		}

		public static bool operator !=(EntityId a, EntityId b)
		{
			if (ReferenceEquals(a, b))
			{
				return false;
			}
			if (((object)a == null) || ((object)b == null))
			{
				return true;
			}

			return a.Type != b.Type || a.Guid != b.Guid;
		}

		public override string ToString()
		{
			return String.Format("{0}.{1}.{2}", this.Type, this.Guid, this.Durability);
		}

		public bool IsPerson
		{
			get { return this.Key.StartsWith("Person"); }
		}

		public bool IsBusiness
		{
			get { return this.Key.StartsWith("Business"); }
		}

		public bool IsLocation
		{
			get { return this.Key.StartsWith("Location"); }
		}

		public bool IsPhone
		{
			get { return this.Key.StartsWith("Phone"); }
		}
	}
}
