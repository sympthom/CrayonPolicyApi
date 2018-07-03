using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crayon.Api.Policy.RestSharpRepository
{
    public sealed class RestSharpPolicyClient : IPolicyClient
    {
        private readonly RestClient _client;
        private readonly RestSharpFactory _factory;
        private readonly ILogger _logger;

        public RestSharpPolicyClient(IApiConfiguration configuration, ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _client = new RestClient(configuration.BaseUri);
            _factory = new RestSharpFactory("PolicyService", configuration, logger);
        }

        public async Task<ResponseMessage<Policy>> GetByIdAsync(int id)
        {
            var request = _factory.Create(Method.GET, id.ToString());

            var response = await _client
                .ExecuteTaskAsync<Policy>(request);

            return new ResponseMessage<Policy>(response.StatusCode.ToString(), response.Data);
        }

        public async Task<ResponseMessage<IEnumerable<Policy>>> GetAllAsync()
        {
            var request = _factory.Create(Method.GET);

            var response = await _client
                .ExecuteTaskAsync<List<Policy>>(request);

            return new ResponseMessage<IEnumerable<Policy>>(response.StatusCode.ToString(), response.Data);
        }

        public async Task<ResponseMessage> InsertAsync(Policy policy)
        {
            var request = _factory.Create(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(policy);

            var response = await _client.ExecuteTaskAsync(request);

            return new ResponseMessage(response.StatusCode.ToString());
        }

        public async Task<ResponseMessage> UpdateAsync(int id, Policy policy)
        {
            var request = _factory.Create(Method.PUT, id.ToString());
            request.RequestFormat = DataFormat.Json;
            request.AddBody(policy);

            var response = await _client.ExecuteTaskAsync(request);

            return new ResponseMessage(response.StatusCode.ToString());
        }

        public async Task<ResponseMessage> DeleteAsync(int id)
        {
            var request = _factory.Create(Method.DELETE, id.ToString());

            var response = await _client.ExecuteTaskAsync(request);

            return new ResponseMessage(response.StatusCode.ToString());
        }
    }  
}
