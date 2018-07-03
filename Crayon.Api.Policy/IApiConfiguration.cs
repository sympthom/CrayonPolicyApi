using System;
using System.Collections.Generic;
using System.Text;

namespace Crayon.Api.Policy
{
    public interface IApiConfiguration
    {
        string BaseUri { get; set; }

        string Username { get; set; }

        string Password { get; set; }
    }
}
