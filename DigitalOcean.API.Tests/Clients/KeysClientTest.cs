using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using NSubstitute;
using RestSharp;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class KeysClientTest {
        [Fact]
        public void CorrectRequestForGetAll() {
            var factory = Substitute.For<IConnection>();
            var client = new KeysClient(factory);

            client.GetAll();

            factory.Received().GetPaginated<Key>("account/keys", null, "ssh_keys");
        }

        [Fact]
        public void CorrectRequestForCreate() {
            var factory = Substitute.For<IConnection>();
            var client = new KeysClient(factory);

            var body = new Models.Requests.Key { Name = "example" };
            client.Create(body);

            factory.Received().ExecuteRequest<Key>("account/keys", null, body, "ssh_key", Method.POST);
        }

        [Fact]
        public void CorrectRequestForGetId() {
            var factory = Substitute.For<IConnection>();
            var client = new KeysClient(factory);

            client.Get(9001L);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == 9001.ToString());
            factory.Received().ExecuteRequest<Key>("account/keys/{id}", parameters, null, "ssh_key");
        }

        [Fact]
        public void CorrectRequestForGetFingerprint() {
            var factory = Substitute.For<IConnection>();
            var client = new KeysClient(factory);

            client.Get("fingerprint");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "fingerprint");
            factory.Received().ExecuteRequest<Key>("account/keys/{id}", parameters, null, "ssh_key");
        }

        [Fact]
        public void CorrectRequestForUpdateId() {
            var factory = Substitute.For<IConnection>();
            var client = new KeysClient(factory);

            var body = new Models.Requests.UpdateKey { Name = "example" };
            client.Update(9001L, body);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == 9001.ToString());
            factory.Received().ExecuteRequest<Key>("account/keys/{id}", parameters, body, "ssh_key", Method.PUT);
        }

        [Fact]
        public void CorrectRequestForDeleteId() {
            var factory = Substitute.For<IConnection>();
            var client = new KeysClient(factory);

            client.Delete(9001L);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == 9001.ToString());
            factory.Received().ExecuteRaw("account/keys/{id}", parameters, null, Method.DELETE);
        }

        [Fact]
        public void CorrectRequestForDeleteFingerprint() {
            var factory = Substitute.For<IConnection>();
            var client = new KeysClient(factory);

            client.Delete("fingerprint");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "fingerprint");
            factory.Received().ExecuteRaw("account/keys/{id}", parameters, null, Method.DELETE);
        }
    }
}
