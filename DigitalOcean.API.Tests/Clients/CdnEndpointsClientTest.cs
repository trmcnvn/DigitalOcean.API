using System.Collections.Generic;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using NSubstitute;
using RestSharp;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class CdnEndpointsClientTest {
        [Fact]
        public void CorrectRequestForGetAll() {
            var factory = Substitute.For<IConnection>();
            var client = new CdnEndpointsClient(factory);

            client.GetAll();

            factory.Received().GetPaginated<CdnEndpoint>("cdn/endpoints", null, "endpoints");
        }

        [Fact]
        public void CorrectRequestForGet() {
            var factory = Substitute.For<IConnection>();
            var client = new CdnEndpointsClient(factory);

            client.Get("endpoint:abc123");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "endpoint:abc123");
            factory.Received().ExecuteRequest<CdnEndpoint>("cdn/endpoints/{endpoint_id}", parameters, null, "endpoint");
        }

        [Fact]
        public void CorrectRequestForCreate() {
            var factory = Substitute.For<IConnection>();
            var client = new CdnEndpointsClient(factory);

            var body = new Models.Requests.CdnEndpoint();
            client.Create(body);

            factory.Received().ExecuteRequest<CdnEndpoint>("cdn/endpoints", null, body, "endpoint", Method.POST);
        }

        [Fact]
        public void CorrectRequestForUpdate() {
            var factory = Substitute.For<IConnection>();
            var client = new CdnEndpointsClient(factory);

            var body = new Models.Requests.UpdateCdnEndpoint();
            client.Update("endpoint:abc123", body);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "endpoint:abc123");
            factory.Received().ExecuteRequest<CdnEndpoint>("cdn/endpoints/{endpoint_id}", parameters, body, "endpoint", Method.PUT);
        }

        [Fact]
        public void CorrectRequestForDelete() {
            var factory = Substitute.For<IConnection>();
            var client = new CdnEndpointsClient(factory);

            client.Delete("endpoint:abc123");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "endpoint:abc123");
            factory.Received().ExecuteRaw("cdn/endpoints/{endpoint_id}", parameters, null, Method.DELETE);
        }

        [Fact]
        public void CorrectRequestForPurgeCache() {
            var factory = Substitute.For<IConnection>();
            var client = new CdnEndpointsClient(factory);

            var body = new Models.Requests.PurgeCdnFiles();
            client.PurgeCache("endpoint:abc123", body);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "endpoint:abc123");
            factory.Received().ExecuteRaw("cdn/endpoints/{endpoint_id}/cache", parameters, body, Method.DELETE);
        }
    }
}
