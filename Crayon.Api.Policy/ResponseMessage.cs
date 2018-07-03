using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Crayon.Api.Policy
{
    public class ResponseMessage
    {
        public string StatusCode { get; internal set; }

        public ResponseMessage(string statusCode)
        {
            this.StatusCode = statusCode;
        }
    }

    public sealed class ResponseMessage<T> : ResponseMessage
    {
        public T Value { get; private set; }

        public ResponseMessage(string statusCode, T value) : base(statusCode)
        {
            this.Value = value;
        }
    }
}
