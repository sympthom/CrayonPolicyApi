using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Crayon.Api.Policy
{
    public sealed class ResilientPolicyApi
    {
        private IPolicyClient _client;
        private IInvocationStrategy _strategy;
        private readonly ILogger _logger;

        public ResilientPolicyApi(ILogger logger)
        {
            _logger = logger;
        }

        public ResilientPolicyApi UseInvocationStrategy(IInvocationStrategy strategy)
        {
            _strategy = strategy;

            return this;
        }

        public ResilientPolicyApi UsePolicyClient(IPolicyClient client)
        {
            _client = client;

            return this;
        }

        public Task<ResponseMessage<Policy>> GetById(int id, CancellationToken token)
        {
            return _strategy.Invoke(() => _client.GetByIdAsync(id));
        }

        public Task<ResponseMessage<IEnumerable<Policy>>> GetAll(CancellationToken token)
        {
            return _strategy.Invoke(() => _client.GetAllAsync());
        }

        public Task<ResponseMessage> Insert(Policy policy, CancellationToken token)
        {
            return _strategy.Invoke(() => _client.InsertAsync(policy));
        }

        public Task<ResponseMessage> Delete(int id, CancellationToken token)
        {
            return _strategy.Invoke(() => _client.DeleteAsync(id));
        }      
    }
}
