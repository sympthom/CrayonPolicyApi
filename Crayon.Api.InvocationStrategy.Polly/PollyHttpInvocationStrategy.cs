using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Polly;
using Polly.Retry;

namespace Crayon.Api.Policy.InvocationStrategy.Polly
{
    public sealed class PollyHttpInvocationStrategy : IInvocationStrategy
    {
        private readonly string[] _httpStatusCodesWorthRetrying = {
            HttpStatusCode.RequestTimeout.ToString(),
            HttpStatusCode.InternalServerError.ToString(),
            HttpStatusCode.BadGateway.ToString(),
            HttpStatusCode.ServiceUnavailable.ToString(),
            HttpStatusCode.GatewayTimeout.ToString()
        };

        private readonly ILogger _logger;

        public PollyHttpInvocationStrategy(ILogger logger)
        {
            _logger = logger;
        }

        public Task<ResponseMessage> Invoke(Func<Task<ResponseMessage>> action)
        {
            var policyWrapper = global::Polly.Policy
                .Handle<HttpRequestException>()
                .OrResult<ResponseMessage>(r => _httpStatusCodesWorthRetrying.Contains(r.StatusCode))
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (exception, timeSpan, retryCount, context) =>
                {
                    var msg = $"Retry {retryCount} " + $"of {context.OperationKey} " + $"using {context.PolicyKey}, " + $"due to: {exception}.";
                    _logger.Warning(msg);
                    _logger.Information(msg);
                });

            return policyWrapper.ExecuteAsync(() => action());
        }

        public Task<ResponseMessage<T>> Invoke<T>(Func<Task<ResponseMessage<T>>> action)
        {
            var policyWrapper = global::Polly.Policy
                .Handle<HttpRequestException>()
                .OrResult<ResponseMessage<T>>(r => _httpStatusCodesWorthRetrying.Contains(r.StatusCode))
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (exception, timeSpan, retryCount, context) =>
                {
                    var msg = $"Retry {retryCount} " + $"of {context.OperationKey} " + $"using {context.PolicyKey}, " + $"due to: {exception}.";
                    _logger.Warning(msg);
                    _logger.Information(msg);
                });

            return policyWrapper.ExecuteAsync(() => action());
        }
    }
}
