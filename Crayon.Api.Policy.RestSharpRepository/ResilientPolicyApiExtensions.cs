using System;
using System.Collections.Generic;
using System.Text;

namespace Crayon.Api.Policy.RestSharpRepository
{
    public static class ResilientPolicyApiExtensions
    {
        public static ResilientPolicyApi UseRestSharpPolicyClient(this ResilientPolicyApi value, IApiConfiguration configuration, ILogger logger)
        {
            return value.UsePolicyClient(new RestSharpPolicyClient(configuration, logger));
        }
    }
}
