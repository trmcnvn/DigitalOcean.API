using System.Collections.Generic;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using NSubstitute;
using RestSharp;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class VpcClientTest {
        [Fact]
        public void CorrectRequestForGetAll() {
            var factory = Substitute.For<IConnection>();
            var client = new VpcClient(factory);

            client.GetAll();

            factory.Received().GetPaginated<Vpc>("vpcs", null, "vpcs");
        }

        [Fact]
        public void CorrectRequestForCreate() {
            var factory = Substitute.For<IConnection>();
            var client = new VpcClient(factory);

            var body = new Models.Requests.Vpc();
            client.Create(body);

            factory.Received().ExecuteRequest<Vpc>("vpcs", null, body, "vpc", Method.POST);
        }

        [Fact]
        public void CorrectRequestForGet() {
            var factory = Substitute.For<IConnection>();
            var client = new VpcClient(factory);

            client.Get("abcdefg");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "abcdefg");
            factory.Received().ExecuteRequest<Vpc>("vpcs/{id}", parameters, null, "vpc");
        }

        [Fact]
        public void CorrectRequestForDelete() {
            var factory = Substitute.For<IConnection>();
            var client = new VpcClient(factory);

            client.Delete("abcdefg");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "abcdefg");
            factory.Received().ExecuteRaw("vpcs/{id}", parameters, null, Method.DELETE);
        }

        [Fact]
        public void CorrectRequestForUpdate() {
            var factory = Substitute.For<IConnection>();
            var client = new VpcClient(factory);

            var body = new Models.Requests.UpdateVpc();
            client.Update("abcdefg", body);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "abcdefg");
            factory.Received().ExecuteRequest<Vpc>("vpcs/{id}", parameters, body, "vpc", Method.PUT);
        }

        [Fact]
        public void CorrectRequestForPartialUpdate() {
            var factory = Substitute.For<IConnection>();
            var client = new VpcClient(factory);

            var body = new Models.Requests.UpdateVpc();
            client.PartialUpdate("abcdefg", body);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "abcdefg");
            factory.Received().ExecuteRequest<Vpc>("vpcs/{id}", parameters, body, "vpc", Method.PATCH);
        }

        [Fact]
        public void CorrectRequestForListMembers() {
            var factory = Substitute.For<IConnection>();
            var client = new VpcClient(factory);

            client.ListMembers("abcdefg");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "abcdefg");
            factory.Received().GetPaginated<VpcMember>("vpcs/{id}/members", parameters, "members");
        }
    }
}
