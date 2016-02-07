using System;

namespace ProApiLibrary.Api.Exceptions
{
	/// <summary>
	/// Copyright 2015 Whitepages, Inc.
	/// </summary>
	public class DataSourceException : Exception
	{
		private readonly Exception _innerException;
		
		public DataSourceException(Exception exc)
			: base(exc.Message)
		{
			_innerException = exc;
		}

		public new Exception InnerException
		{
			get { return _innerException; }
		}
	}
}
