using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using NSubstitute;
using RestSharp;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class DomainsTest {
        [Fact]
        public void CorrectRequestForGetAll() {
            var factory = Substitute.For<IConnection>();
            var domainClient = new DomainsClient(factory);

            domainClient.GetAll();
            factory.Received().GetPaginated<Domain>("domains", null, "domains");
        }

        [Fact]
        public void CorrectRequireForCreate() {
            var factory = Substitute.For<IConnection>();
            var domainClient = new DomainsClient(factory);

            var data = new Models.Requests.Domain { Name = "CNAME" };
            domainClient.Create(data);

            factory.Received().ExecuteRequest<Domain>("domains", null, data, "domain", Method.POST);
        }

        [Fact]
        public void CorrectRequestForGet() {
            var factory = Substitute.For<IConnection>();
            var domainClient = new DomainsClient(factory);

            domainClient.Get("vevix.net");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "vevix.net");
            factory.Received().ExecuteRequest<Domain>("domains/{name}", parameters, null, "domain");
        }

        [Fact]
        public void CorrectRequestForDelete() {
            var factory = Substitute.For<IConnection>();
            var domainClient = new DomainsClient(factory);

            domainClient.Delete("vevix.net");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "vevix.net");
            factory.Received().ExecuteRaw("domains/{name}", parameters, Method.DELETE);
        }

        [Fact]
        public async Task CorrectResponseForGet() {
            var allIds = await Factory.GetClient().Domains.GetAll();
            Assert.NotEmpty(allIds);
            Assert.IsType<Domain>(allIds[0]);
            Assert.Equal("vevix.net", allIds[0].Name);

            var result = await Factory.GetClient().Domains.Get("vevix.net");
            Assert.Equal(allIds[0].Name, result.Name);
        }

        [Fact]
        public async Task CorrectResponseForCreateDelete() {
            var body = new Models.Requests.Domain {
                Name = "testing.vevix.net",
                IpAddress = "10.10.10.10"
            };
            var create = await Factory.GetClient().Domains.Create(body);
            Assert.Equal("testing.vevix.net", create.Name);

            await Factory.GetClient().Domains.Delete("testing.vevix.net");
        }
    }
}