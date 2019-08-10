using System.Collections.Generic;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using NSubstitute;
using RestSharp;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class FloatingIpsClientTest {
        [Fact]
        public void CorrectRequestForGetAll() {
            var factory = Substitute.For<IConnection>();
            var client = new FloatingIpsClient(factory);
            client.GetAll();
            factory.Received().GetPaginated<FloatingIp>("floating_ips", null, "floating_ips");
        }

        [Fact]
        public void CorrectRequestForCreate() {
            var factory = Substitute.For<IConnection>();
            var client = new FloatingIpsClient(factory);

            var body = new Models.Requests.FloatingIp();
            client.Create(body);
            factory.Received().ExecuteRequest<FloatingIp>("floating_ips", null, body, "floating_ip", Method.POST);
        }

        [Fact]
        public void CorrectRequestForGet() {
            var factory = Substitute.For<IConnection>();
            var client = new FloatingIpsClient(factory);

            client.Get("1.2.3.4");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1.2.3.4");
            factory.Received().ExecuteRequest<FloatingIp>("floating_ips/{ip}", parameters, null, "floating_ip");
        }

        [Fact]
        public void CorrectRequestForDelete() {
            var factory = Substitute.For<IConnection>();
            var client = new FloatingIpsClient(factory);

            client.Delete("1.2.3.4");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1.2.3.4");
            factory.Received().ExecuteRaw("floating_ips/{ip}", parameters, null, Method.DELETE);
        }
    }
}
