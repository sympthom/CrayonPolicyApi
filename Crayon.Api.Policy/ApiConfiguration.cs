using System;
using System.Collections.Generic;
using System.Text;

namespace Crayon.Api.Policy
{
    public sealed class ApiConfiguration : IApiConfiguration
    {
        public string BaseUri { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
