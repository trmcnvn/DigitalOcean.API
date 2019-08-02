using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using NSubstitute;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class AccountClientTest {
        [Fact]
        public void CorrectRequestForGet() {
            var factory = Substitute.For<IConnection>();
            var client = new AccountClient(factory);

            client.Get();

            factory.Received().ExecuteRequest<Account>("/account", null, null, "account");
        }
    }
}
