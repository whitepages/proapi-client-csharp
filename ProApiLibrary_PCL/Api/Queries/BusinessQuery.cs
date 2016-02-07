using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProApiLibrary.Data.Entities;

namespace ProApiLibrary.Api.Queries
{
	/// <summary>
	/// The root concrete class for all Business queries
	/// </summary>
	public class BusinessQuery : WhereQuery
	{
		public BusinessQuery()
		{
			
		}

		public BusinessQuery(EntityId id) : base(id)
		{
			
		}

		public BusinessQuery(string name)
		{
			this.Name = name;
		}

		public BusinessQuery(string name, string city, string stateCode, string postalCode)
			: base(city, stateCode, postalCode)
		{
			this.Name = name;
		}

		public string Name { get; set; }

		public override string ParamsToString()
		{
			return ParamToString("name", this.Name) + base.ParamsToString();
		}
	}
}
