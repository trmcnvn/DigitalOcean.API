using System.Collections.Generic;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Requests;
using DigitalOcean.API.Models.Responses;
using NSubstitute;
using RestSharp;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class ProjectResourcesClientTest {
        [Fact]
        public void CorrectRequestForGetResources() {
            var factory = Substitute.For<IConnection>();
            var client = new ProjectResourcesClient(factory);

            client.GetResources("project:abc123");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "project:abc123");
            factory.Received().GetPaginated<ProjectResource>("projects/{project_id}/resources", parameters, "resources");
        }

        [Fact]
        public void CorrectRequestForGetDefaultResources() {
            var factory = Substitute.For<IConnection>();
            var client = new ProjectResourcesClient(factory);

            client.GetDefaultResources();

            factory.Received().GetPaginated<ProjectResource>("projects/default/resources", null, "resources");
        }

        [Fact]
        public void CorrectRequestForAssignResources() {
            var factory = Substitute.For<IConnection>();
            var client = new ProjectResourcesClient(factory);

            var resources = new AssignResourceNames() {
                Resources = new List<string>() { "do:droplet:9001", "do:droplet:9002" }
            };
            client.AssignResources("project:abc123", resources);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "project:abc123");
            factory.Received().ExecuteRequest<List<ProjectResource>>("projects/{project_id}/resources", parameters, resources, "resources", Method.POST);
        }

        [Fact]
        public void CorrectRequestForAssignDefaultResources() {
            var factory = Substitute.For<IConnection>();
            var client = new ProjectResourcesClient(factory);

            var resources = new AssignResourceNames() {
                Resources = new List<string>() { "do:droplet:9001", "do:droplet:9002" }
            };
            client.AssignDefaultResources(resources);

            factory.Received().ExecuteRequest<List<ProjectResource>>("projects/default/resources", null, resources, "resources", Method.POST);
        }
    }
}
