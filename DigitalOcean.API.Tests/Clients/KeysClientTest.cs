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
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DigitalOcean.API.Tests.Clients
{
    [TestClass]
    public class KeysClientTest
    {
        [TestMethod]
        public void TestKeysGetAll()
        {
            var client = Factory.GetClient();

            var task = client.Keys.GetAll();
            task.Wait(5 * 60 * 1000);

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(task.Result);
        }

        [Fact]
        public void CorrectRequestForGetAll() {
            var factory = Substitute.For<IConnection>();
            var client = new KeysClient(factory);

            client.GetAll();

            factory.Received().GetPaginated<Key>("keys", null, "ssh_keys");
        }

        [Fact]
        public void CorrectRequestForCreate() {
            var factory = Substitute.For<IConnection>();
            var client = new KeysClient(factory);

            var body = new Models.Requests.Key { Name = "example" };
            client.Create(body);

            factory.Received().ExecuteRequest<Key>("keys", null, body, "ssh_key", Method.POST);
        }

        [Fact]
        public void CorrectRequestForGetId() {
            var factory = Substitute.For<IConnection>();
            var client = new KeysClient(factory);

            client.Get(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            factory.Received().ExecuteRequest<Key>("keys/{id}", parameters, null, "ssh_key");
        }

        [Fact]
        public void CorrectRequestForGetFingerprint() {
            var factory = Substitute.For<IConnection>();
            var client = new KeysClient(factory);

            client.Get("fingerprint");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "fingerprint");
            factory.Received().ExecuteRequest<Key>("keys/{id}", parameters, null, "ssh_key");
        }

        [Fact]
        public void CorrectRequestForUpdateId() {
            var factory = Substitute.For<IConnection>();
            var client = new KeysClient(factory);

            var body = new Models.Requests.Key { Name = "example" };
            client.Update(9001, body);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            factory.Received().ExecuteRequest<Key>("keys/{id}", parameters, body, "ssh_key", Method.PUT);
        }

        [Fact]
        public void CorrectRequestForUpdateFingerprint() {
            var factory = Substitute.For<IConnection>();
            var client = new KeysClient(factory);

            var body = new Models.Requests.Key { Name = "example" };
            client.Update("fingerprint", body);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "fingerprint");
            factory.Received().ExecuteRequest<Key>("keys/{id}", parameters, body, "ssh_key", Method.PUT);
        }

        [Fact]
        public void CorrectRequestForDeleteId() {
            var factory = Substitute.For<IConnection>();
            var client = new KeysClient(factory);

            client.Delete(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            factory.Received().ExecuteRaw("keys/{id}", parameters, Method.DELETE);
        }

        [Fact]
        public void CorrectRequestForDeleteFingerprint() {
            var factory = Substitute.For<IConnection>();
            var client = new KeysClient(factory);

            client.Delete("fingerprint");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "fingerprint");
            factory.Received().ExecuteRaw("keys/{id}", parameters, Method.DELETE);
        }
    }
}
