using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace ProApiLibrary.Api.Clients.Utils
{
	/// <summary>
	/// Copyright 2015 Whitepages, Inc.
	/// </summary>
	public class HttpResponse : IData
	{
		private readonly HttpStatusCode _responseCode;
		private readonly Uri _uri;
		private readonly IDictionary<String, List<String>> _headerFields;
		private readonly Stream _body;

		public HttpResponse(HttpStatusCode responseCode, Uri uri, IDictionary<String, List<String>> headerFields, Stream body) 
		{
			_responseCode = responseCode;
			_uri = uri;
			_headerFields = headerFields;
			_body = body;
		}

		public HttpStatusCode ResponseCode 
		{
			get { return _responseCode; }
		}

		public Uri Uri 
		{
			get { return _uri; }
		}

		public IDictionary<String, List<String>> HeaderFields
		{
			get { return _headerFields; }
		}

		public Stream Body 
		{
			get { return _body; }
		}

		public override string ToString() 
		{
			return "HttpResponse{responseCode=" + _responseCode + ", uri=" + _uri + "}";
		}
	}
}
