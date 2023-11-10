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

            var body = new AssignResourceNames();
            client.AssignResources("project:abc123", body);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "project:abc123");
            factory.Received().ExecuteRequest<List<ProjectResource>>("projects/{project_id}/resources", parameters, body, "resources", Method.Post);
        }

        [Fact]
        public void CorrectRequestForAssignDefaultResources() {
            var factory = Substitute.For<IConnection>();
            var client = new ProjectResourcesClient(factory);

            var body = new AssignResourceNames();
            client.AssignDefaultResources(body);

            factory.Received().ExecuteRequest<List<ProjectResource>>("projects/default/resources", null, body, "resources", Method.Post);
        }
    }
}
