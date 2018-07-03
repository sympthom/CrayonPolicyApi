using System;
using System.Threading;
using System.Threading.Tasks;
using Crayon.Api.Policy.RestSharpRepository;
using Crayon.Api.Policy.InvocationStrategy.Polly;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crayon.Api.Policy.Test
{
    [TestClass]
    public class UnitTest1
    {
        private ILogger _logger;
        private IApiConfiguration _configuration;

        [TestInitialize]
        public void Initialize()
        {
            _logger = new DebugLogger();
            _configuration = new ApiConfiguration
            {
                BaseUri = "http://crayonapi.azurewebsites.net/api",
                Username = "Crayon",
                Password = "Crayon"
            };
        }

        [TestMethod]
        public async Task TestInsertPolicy()
        {
            Assert.IsNotNull(_logger);
            Assert.IsNotNull(_configuration);

            var token = new CancellationToken();

            var response = await new ResilientPolicyApi(_logger)
                .UseRestSharpPolicyClient(_configuration, _logger)
                .UsePollyHttpInvocationStrategy(_logger)
                .Insert(new Policy
                {
                    Id = 3,
                    InsuranceNr = "fjupp",
                    IsComplete = true
                }, token);

            Assert.IsNotNull(response);
            Assert.AreEqual(response.StatusCode, "OK");
        }

        [TestMethod]
        public async Task TestUpdatePolicy()
        {
            Assert.IsNotNull(_logger);
            Assert.IsNotNull(_configuration);

            var token = new CancellationToken();

            var response = await new ResilientPolicyApi(_logger)
                .UseRestSharpPolicyClient(_configuration, _logger)
                .UsePollyHttpInvocationStrategy(_logger)
                .Update(3, new Policy
                {
                    Id = 3,
                    InsuranceNr = "fjupp",
                    IsComplete = true
                }, token);

            Assert.IsNotNull(response);
            Assert.AreEqual(response.StatusCode, "OK");
        }

        [TestMethod]
        public async Task TestGetAll()
        {
            Assert.IsNotNull(_logger);
            Assert.IsNotNull(_configuration);

            var token = new CancellationToken();

            var response = await new ResilientPolicyApi(_logger)
                .UseRestSharpPolicyClient(_configuration, _logger)
                .UsePollyHttpInvocationStrategy(_logger)
                .GetAll(token);

            Assert.IsNotNull(response);
            Assert.AreEqual(response.StatusCode, "OK");
        }

        [TestMethod]
        public async Task TestDelete()
        {
            Assert.IsNotNull(_logger);
            Assert.IsNotNull(_configuration);

            var token = new CancellationToken();

            var response = await new ResilientPolicyApi(_logger)
                .UseRestSharpPolicyClient(_configuration, _logger)
                .UsePollyHttpInvocationStrategy(_logger)
                .Delete(1, token);

            Assert.IsNotNull(response);
            Assert.AreEqual(response.StatusCode, "OK");            
        }

        [TestMethod]
        public async Task TestGetById()
        {
            Assert.IsNotNull(_logger);
            Assert.IsNotNull(_configuration);

            var token = new CancellationToken();

            var response = await new ResilientPolicyApi(_logger)
                .UseRestSharpPolicyClient(_configuration, _logger)
                .UsePollyHttpInvocationStrategy(_logger)
                .GetById(1, token);

            Assert.IsNotNull(response);
            Assert.AreEqual(response.StatusCode, "OK");
            Assert.IsNotNull(response.Value);
            Assert.AreEqual(response.Value.Id, 1);
        }
    }
}
