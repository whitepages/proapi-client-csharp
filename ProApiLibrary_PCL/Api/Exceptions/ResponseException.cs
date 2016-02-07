namespace ProApiLibrary.Api.Exceptions
{
	/// <summary>
	/// Copyright 2015 Whitepages, Inc.
	/// </summary>
	public class ResponseException : ResponseDecoderException
	{
		public ResponseException(string message) : base(message)
		{
			
		}
	}
}
