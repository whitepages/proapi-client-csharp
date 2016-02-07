using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProApiLibrary.Data.Associations
{
	public enum ContactType
	{
		Other,
		Work,
		Home,
		Business
	}

	/// <summary>
	/// Copyright @2015 Whitepages, Inc.
	/// </summary>
	public interface IContactTyped
	{
		ContactType? ContactType { get; }
	}
}
