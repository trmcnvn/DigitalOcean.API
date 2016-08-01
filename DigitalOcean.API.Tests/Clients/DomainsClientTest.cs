using System.Collections.Generic;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using NSubstitute;
using RestSharp;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class DomainsClientTest {
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
            factory.Received().ExecuteRaw("domains/{name}", parameters, null, Method.DELETE);
        }
    }
}