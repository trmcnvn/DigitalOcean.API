using System.Collections.Generic;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Requests;
using NSubstitute;
using RestSharp;
using Xunit;
using Image = DigitalOcean.API.Models.Responses.Image;

namespace DigitalOcean.API.Tests.Clients {
    public class ImagesClientTest {
        [Fact]
        public void CorrectRequestForGetAll() {
            var factory = Substitute.For<IConnection>();
            var client = new ImagesClient(factory);

            client.GetAll();
            factory.Received().GetPaginated<Image>("images", null, "images");

            client.GetAll(ImageType.Application);
            factory.Received().GetPaginated<Image>("images?type=application", null, "images");

            client.GetAll(ImageType.Distribution);
            factory.Received().GetPaginated<Image>("images?type=distribution", null, "images");

            client.GetAll(ImageType.Private);
            factory.Received().GetPaginated<Image>("images?private=true", null, "images");
        }

        public void CorrectRequestForCreate() {
            var factory = Substitute.For<IConnection>();
            var client = new ImagesClient(factory);

            var body = new Models.Requests.Image();
            client.Create(body);

            factory.Received().ExecuteRequest<Image>("images", null, body, "image", Method.POST);
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
            factory.Received().ExecuteRaw("images/{id}", parameters, null, Method.DELETE);
        }

        [Fact]
        public void CorrectRequestForUpdate() {
            var factory = Substitute.For<IConnection>();
            var client = new ImagesClient(factory);

            var body = new Models.Requests.UpdateImage { Name = "example" };
            client.Update(9001, body);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            factory.Received().ExecuteRequest<Image>("images/{id}", parameters, body, "image", Method.PUT);
        }
    }
}
