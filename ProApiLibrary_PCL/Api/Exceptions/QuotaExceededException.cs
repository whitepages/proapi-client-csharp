namespace ProApiLibrary.Api.Exceptions
{
	/// <summary>
	/// Copyright 2015 Whitepages, Inc.
	/// </summary>
	public class QuotaExceededException : ResponseException
	{
		public QuotaExceededException(string message) : base(message)
		{
			
		}
	}
}
