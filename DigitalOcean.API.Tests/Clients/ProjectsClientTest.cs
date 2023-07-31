using System.Collections.Generic;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using NSubstitute;
using RestSharp;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class ProjectsClientTest {
        [Fact]
        public void CorrectRequestForGetAll() {
            var factory = Substitute.For<IConnection>();
            var client = new ProjectsClient(factory);

            client.GetAll();
            factory.Received().GetPaginated<Project>("projects", null, "projects");
        }

        [Fact]
        public void CorrectRequireForCreate() {
            var factory = Substitute.For<IConnection>();
            var client = new ProjectsClient(factory);

            var data = new Models.Requests.Project();
            client.Create(data);

            factory.Received().ExecuteRequest<Project>("projects", null, data, "project", Method.Post);
        }

        [Fact]
        public void CorrectRequestForGet() {
            var factory = Substitute.For<IConnection>();
            var client = new ProjectsClient(factory);

            client.Get("project:abc123");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "project:abc123");
            factory.Received().ExecuteRequest<Project>("projects/{project_id}", parameters, null, "project");
        }

        [Fact]
        public void CorrectRequestForGetDefault() {
            var factory = Substitute.For<IConnection>();
            var client = new ProjectsClient(factory);

            client.GetDefault();

            factory.Received().ExecuteRequest<Project>("projects/default", null, null, "project");
        }

        [Fact]
        public void CorrectRequestForUpdate() {
            var factory = Substitute.For<IConnection>();
            var client = new ProjectsClient(factory);

            var data = new Models.Requests.UpdateProject();
            client.Update("project:abc123", data);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "project:abc123");
            factory.Received().ExecuteRequest<Project>("projects/{project_id}", parameters, data, "project", Method.Put);
        }

        [Fact]
        public void CorrectRequestForUpdateDefault() {
            var factory = Substitute.For<IConnection>();
            var client = new ProjectsClient(factory);

            var data = new Models.Requests.UpdateProject();
            client.UpdateDefault(data);

            factory.Received().ExecuteRequest<Project>("projects/default", null, data, "project", Method.Put);
        }

        [Fact]
        public void CorrectRequestForPatch() {
            var factory = Substitute.For<IConnection>();
            var client = new ProjectsClient(factory);

            var data = new Models.Requests.PatchProject();
            client.Patch("project:abc123", data);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "project:abc123");
            factory.Received().ExecuteRequest<Project>("projects/{project_id}", parameters, data, "project", Method.Patch);
        }

        [Fact]
        public void CorrectRequestForPatchDefault() {
            var factory = Substitute.For<IConnection>();
            var client = new ProjectsClient(factory);

            var data = new Models.Requests.PatchProject();
            client.PatchDefault(data);

            factory.Received().ExecuteRequest<Project>("projects/default", null, data, "project", Method.Patch);
        }

        [Fact]
        public void CorrectRequestForDelete() {
            var factory = Substitute.For<IConnection>();
            var client = new ProjectsClient(factory);

            client.Delete("notarealid");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "notarealid");
            factory.Received().ExecuteRaw("projects/{project_id}", parameters, null, Method.Delete);
        }
    }
}
