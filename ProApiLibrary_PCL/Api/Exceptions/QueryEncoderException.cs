using System;

namespace ProApiLibrary.Api.Exceptions
{
	/// <summary>
	/// Copyright 2015 Whitepages, Inc.
	/// </summary>
	public class QueryEncoderException : Exception
	{
		private readonly Exception _innerException;

		public QueryEncoderException(string message) : base(message)
		{
			
		}

		public QueryEncoderException(Exception inner)
		{
			_innerException = inner;
		}

		public new Exception InnerException
		{
			get { return _innerException; }
		}
	}
}
