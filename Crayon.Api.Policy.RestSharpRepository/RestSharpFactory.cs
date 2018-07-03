using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crayon.Api.Policy.RestSharpRepository
{
    internal sealed class RestSharpFactory
    {
        private readonly string _service;
        private readonly IApiConfiguration _configuration;
        private readonly ILogger _logger;

        public RestSharpFactory(string service, IApiConfiguration configuration, ILogger logger)
        {
            _service = service;
            _configuration = configuration;
            _logger = logger;
        }

        public RestRequest Create(Method method, params string[] asd)
        {
            var request = new RestRequest($"{_service}/{string.Join("/", asd)}", method);
            request.AddHeader("UserID", _configuration.Username);
            request.AddHeader("PWD", _configuration.Password);

            return request;
        }
    }
}
