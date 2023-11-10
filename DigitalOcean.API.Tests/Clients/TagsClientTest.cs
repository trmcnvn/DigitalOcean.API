using System.Collections.Generic;
using System.Linq;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using NSubstitute;
using RestSharp;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class TagsClientTest {
        [Fact]
        public void CorrectRequestForGet() {
            var factory = Substitute.For<IConnection>();
            var client = new TagsClient(factory);

            client.Get("notarealtag");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "notarealtag");
            factory.Received().ExecuteRequest<Tag>("tags/{name}", parameters, null, "tag");
        }

        [Fact]
        public void CorrectRequestForGetAll() {
            var factory = Substitute.For<IConnection>();
            var client = new TagsClient(factory);

            client.GetAll();

            factory.Received().GetPaginated<Tag>("tags", null, "tags");
        }

        [Fact]
        public void CorrectRequestForCreate() {
            var factory = Substitute.For<IConnection>();
            var client = new TagsClient(factory);

            client.Create("notarealtag");

            factory.Received().ExecuteRequest<Tag>("tags", null, Arg.Is<Models.Requests.Tag>(data => data.Name == "notarealtag"), "tag", Method.Post);
        }

        [Fact]
        public void CorrectRequestForDelete() {
            var factory = Substitute.For<IConnection>();
            var client = new TagsClient(factory);

            client.Delete("notarealtag");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "notarealtag");
            factory.Received().ExecuteRaw("tags/{name}", parameters, null, Method.Delete);
        }

        [Fact]
        public void CorrectRequestForTag() {
            var factory = Substitute.For<IConnection>();
            var client = new TagsClient(factory);

            var resources = new Models.Requests.TagResources() {
                Resources = new List<Models.Requests.TagResource>() {
                    new Models.Requests.TagResource()
                    {
                        Id = "9001",
                        Type = "droplet"
                    },
                    new Models.Requests.TagResource()
                    {
                        Id = "9002",
                        Type = "droplet"
                    }
                }
            };

            client.Tag("notarealtag", resources);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "notarealtag");
            var body = Arg.Is<Models.Requests.TagResources>(tr => tr.Resources.SequenceEqual(resources.Resources));
            factory.Received().ExecuteRaw("tags/{name}/resources", parameters, body, Method.Post);
        }

        [Fact]
        public void CorrectRequestForUntag() {
            var factory = Substitute.For<IConnection>();
            var client = new TagsClient(factory);

            var resources = new Models.Requests.TagResources() {
                Resources = new List<Models.Requests.TagResource>() {
                    new Models.Requests.TagResource()
                    {
                        Id = "9001",
                        Type = "droplet"
                    },
                    new Models.Requests.TagResource()
                    {
                        Id = "9002",
                        Type = "droplet"
                    }
                }
            };

            client.Untag("notarealtag", resources);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "notarealtag");
            var body = Arg.Is<Models.Requests.TagResources>(tr => tr.Resources.SequenceEqual(resources.Resources));
            factory.Received().ExecuteRaw("tags/{name}/resources", parameters, body, Method.Delete);
        }
    }
}
