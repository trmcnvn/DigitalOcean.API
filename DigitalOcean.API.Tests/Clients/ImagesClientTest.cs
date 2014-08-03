using System.Collections.Generic;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using NSubstitute;
using RestSharp;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class ImagesClientTest {
        [Fact]
        public void CorrectRequestForGetAll() {
            var factory = Substitute.For<IConnection>();
            var client = new ImagesClient(factory);

            client.GetAll();

            factory.Received().GetPaginated<Image>("images", null, "images");
        }

        [Fact]
        public void CorrectRequestForGetId() {
            var factory = Substitute.For<IConnection>();
            var client = new ImagesClient(factory);

            client.Get(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            factory.Received().ExecuteRequest<Image>("images/{id}", parameters, null, "image");
        }

        [Fact]
        public void CorrectRequestForGetSlug() {
            var factory = Substitute.For<IConnection>();
            var client = new ImagesClient(factory);

            client.Get("testing");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "testing");
            factory.Received().ExecuteRequest<Image>("images/{id}", parameters, null, "image");
        }

        [Fact]
        public void CorrectRequestForDelete() {
            var factory = Substitute.For<IConnection>();
            var client = new ImagesClient(factory);

            client.Delete(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            factory.Received().ExecuteRaw("images/{id}", parameters, Method.DELETE);
        }

        [Fact]
        public void CorrectRequestForUpdate() {
            var factory = Substitute.For<IConnection>();
            var client = new ImagesClient(factory);

            var body = new Models.Requests.Image { Name = "example" };
            client.Update(9001, body);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            factory.Received().ExecuteRequest<Image>("images/{id}", parameters, body, "image", Method.PUT);
        }
    }
}