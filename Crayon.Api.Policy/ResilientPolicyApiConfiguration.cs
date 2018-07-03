using System;
using System.Collections.Generic;
using System.Text;

namespace Crayon.Api.Policy
{
    public sealed partial class ResilientPolicyApi
    {
        private IPolicyClient _client;
        private IInvocationStrategy _strategy;

        public ResilientPolicyApi UseInvocationStrategy(IInvocationStrategy strategy)
        {
            _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));

            return this;
        }

        public ResilientPolicyApi UsePolicyClient(IPolicyClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));

            return this;
        }
    }
}
