﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EAI.Template.Core.Exceptions
{
    public class APIException : Exception
    {
        public string Code { get;}
        public HttpStatusCode StatusCode { get; }
        public APIException(string code, string message, HttpStatusCode statusCode) : base(message)
        {
            Code = code;
            StatusCode = statusCode;
        }
    }
}
