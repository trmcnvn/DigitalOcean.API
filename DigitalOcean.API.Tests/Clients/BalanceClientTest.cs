using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using NSubstitute;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class BalanceClientTest
    {
        [Fact]
        public void CorrectRequestForGet() {
            var factory = Substitute.For<IConnection>();
            var client = new BalanceClient(factory);

            client.Get();

            factory.Received().ExecuteRequest<Balance>("customers/my/balance", null, null, null);
        }
    }
}
