using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProApiLibrary.Api.Clients.Exceptions
{
	/// <summary>
	/// Copyright 2015 Whitepages, Inc.
	/// </summary>
	public class ResponseDecoderException : Exception
	{
		private readonly Exception _innerException;

		public ResponseDecoderException(Exception innerException)
		{
			_innerException = innerException;
		}

		public new Exception InnerException
		{
			get { return _innerException; }
		}
	}
}
