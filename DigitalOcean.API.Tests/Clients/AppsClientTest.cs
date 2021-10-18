using System.Collections.Generic;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using DigitalOcean.API.Models.Requests;
using NSubstitute;
using RestSharp;
using Xunit;
using AppSpec = DigitalOcean.API.Models.Requests.AppSpec;

namespace DigitalOcean.API.Tests.Clients {
    public class AppsClientTest {
        [Fact]
        public void CorrectRequestForListAllApps() {
            var factory = Substitute.For<IConnection>();
            var client = new AppsClient(factory);

            client.ListAllApps();

            factory.Received().GetPaginated<App>("apps", null, "apps");
        }

        [Fact]
        public void CorrectRequestForRetrieveAnExistingApp() {
            var factory = Substitute.For<IConnection>();
            var client = new AppsClient(factory);

            client.RetrieveExistingApp("test");

            var parameters = Arg.Is<List<Parameter>>(list => (string) list[0].Value == "test");
            factory.Received().ExecuteRequest<App>("apps/{appId}", parameters, null, "app");
        }

        [Fact]
        public void CorrectRequestForListAppDeployments() {
            var factory = Substitute.For<IConnection>();
            var client = new AppsClient(factory);

            client.ListAppDeployments("test");

            var parameters = Arg.Is<List<Parameter>>(list => (string) list[0].Value == "test");
            factory.Received().GetPaginated<Deployment>("apps/{appId}/deployments", parameters, "deployments");
        }

        [Fact]
        public void CorrectRequestForRetrieveAnAppDeployment() {
            var factory = Substitute.For<IConnection>();
            var client = new AppsClient(factory);

            client.RetrieveAppDeployment("test", "test2");

            var parameters = Arg.Is<List<Parameter>>(list =>
                (string) list[0].Value == "test" && (string) list[1].Value == "test2");
            factory.Received().ExecuteRequest<Deployment>("apps/{appId}/deployments/{deploymentId}", parameters, null,
                "deployment");
        }

        [Fact]
        public void CorrectRequestForDeleteAnApp() {
            var factory = Substitute.For<IConnection>();
            var client = new AppsClient(factory);

            client.DeleteApp("test");

            var parameters = Arg.Is<List<Parameter>>(list => (string) list[0].Value == "test");
            factory.Received().ExecuteRaw("apps/{appId}", parameters, null, Method.DELETE);
        }

        [Fact]
        public void CorrectRequestForCreateNewApp() {
            var factory = Substitute.For<IConnection>();
            var client = new AppsClient(factory);
            var app = new AppSpec();
            var specs = new Specs() {Spec = app};
            client.CreateNewApp(specs);

            factory.Received().ExecuteRequest<App>("apps", null, specs, "app", Method.POST);
        }

        [Fact]
        public void CorrectRequestForCreateNewDeployment() {
            var factory = Substitute.For<IConnection>();
            var client = new AppsClient(factory);
            var forceBuild = new ForceBuildApp() {ForceBuild = true};

            client.CreateNewDeployment("test", forceBuild);

            var parameters = Arg.Is<List<Parameter>>(list =>
                (string) list[0].Value == "test");
            factory.Received().ExecuteRequest<Deployment>("apps/{appId}/deployments", parameters, forceBuild,
                "deployment", Method.POST);
        }

        [Fact]
        public void CorrectRequestForCancelDeployment() {
            var factory = Substitute.For<IConnection>();
            var client = new AppsClient(factory);

            client.CancelDeployment("test", "test2");

            var parameters = Arg.Is<List<Parameter>>(list =>
                (string) list[0].Value == "test" && (string) list[1].Value == "test2");
            factory.Received().ExecuteRequest<Deployment>("apps/{appId}/deployments/{deploymentId}", parameters, null,
                "deployment", Method.POST);
        }

    }
}
