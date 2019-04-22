using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using NSubstitute;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class RegionsClientTest {
        [Fact]
        public void CorrectRequestForGetAll() {
            var factory = Substitute.For<IConnection>();
            var client = new RegionsClient(factory);

            client.GetAll();

            factory.Received().GetPaginated<Region>("regions", null, "regions");
        }
    }
}
