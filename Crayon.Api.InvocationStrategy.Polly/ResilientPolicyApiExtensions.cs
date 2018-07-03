using System;
using System.Collections.Generic;
using System.Text;

namespace Crayon.Api.Policy.InvocationStrategy.Polly
{
    public static class ResilientPolicyApiExtensions
    {
        public static ResilientPolicyApi UsePollyHttpInvocationStrategy(this ResilientPolicyApi value, ILogger logger)
        {
            return value.UseInvocationStrategy(new PollyHttpInvocationStrategy(logger));
        }
    }
}
