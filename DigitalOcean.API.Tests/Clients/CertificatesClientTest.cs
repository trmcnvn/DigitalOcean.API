using System.Collections.Generic;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using NSubstitute;
using RestSharp;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class CertificatesClientTest {
        [Fact]
        public void CorrectRequestForGetAll() {
            var factory = Substitute.For<IConnection>();
            var client = new CertificatesClient(factory);

            client.GetAll();

            factory.Received().GetPaginated<Certificate>("certificates", null, "certificates");
        }

        [Fact]
        public void CorrectRequestForGet() {
            var factory = Substitute.For<IConnection>();
            var client = new CertificatesClient(factory);

            client.Get("certificate:abc123");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "certificate:abc123");
            factory.Received().ExecuteRequest<Certificate>("certificates/{certificate_id}", parameters, null, "certificate");
        }

        [Fact]
        public void CorrectRequestForCreate() {
            var factory = Substitute.For<IConnection>();
            var client = new CertificatesClient(factory);

            var body = new Models.Requests.Certificate();
            client.Create(body);

            factory.Received().ExecuteRequest<Certificate>("certificates", null, body, "certificate", Method.POST);
        }

        [Fact]
        public void CorrectRequestForDelete() {
            var factory = Substitute.For<IConnection>();
            var client = new CertificatesClient(factory);

            client.Delete("certificate:abc123");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "certificate:abc123");
            factory.Received().ExecuteRaw("certificates/{certificate_id}", parameters, null, Method.DELETE);
        }
    }
}
