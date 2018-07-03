using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Crayon.Api.Policy
{
    public sealed partial class ResilientPolicyApi
    {        
        private readonly ILogger _logger;

        public ResilientPolicyApi(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }       

        public Task<ResponseMessage<Policy>> GetById(int id, CancellationToken token)
        {
            Validate();

            return _strategy.Invoke(() => _client.GetByIdAsync(id));
        }

        public Task<ResponseMessage<IEnumerable<Policy>>> GetAll(CancellationToken token)
        {
            Validate();

            return _strategy.Invoke(() => _client.GetAllAsync());
        }

        public Task<ResponseMessage> Insert(Policy policy, CancellationToken token)
        {
            Validate();

            return _strategy.Invoke(() => _client.InsertAsync(policy));
        }

        public Task<ResponseMessage> Update(int id, Policy policy, CancellationToken token)
        {
            Validate();

            return _strategy.Invoke(() => _client.UpdateAsync(id, policy));
        }

        public Task<ResponseMessage> Delete(int id, CancellationToken token)
        {
            Validate();

            return _strategy.Invoke(() => _client.DeleteAsync(id));
        }

        private void Validate()
        {
            if (_strategy == null)
                throw new NullReferenceException("The strategy is not defined.");

            if (_client == null)
                throw new NullReferenceException("The client is not defined.");
        }
    }
}
