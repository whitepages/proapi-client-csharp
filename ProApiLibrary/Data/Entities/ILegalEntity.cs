namespace ProApiLibrary.Data.Entities
{
	/// <summary>
	/// /// <p>A common interface for <seealso cref="IPerson"/> and <seealso cref="IBusiness"/>
	/// <seealso cref="IEntity"/> instances.</p>
	/// </summary>
	/// <remarks>
	/// <p>This interface exists for the purposes of typing for Liskov
	/// substitution.</p>
	/// </remarks>
	public interface ILegalEntity : IEntity
	{
	}
}
