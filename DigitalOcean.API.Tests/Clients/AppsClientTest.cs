using System.Collections.Generic;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using NSubstitute;
using RestSharp;
using Xunit;

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

            client.RetrieveAnExistingApp("test");

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

            client.RetrieveAnAppDeployment("test", "test2");

            var parameters = Arg.Is<List<Parameter>>(list =>
                (string) list[0].Value == "test" && (string) list[1].Value == "test2");
            factory.Received().ExecuteRequest<Deployment>("apps/{appId}/deployments/{deploymentId}", parameters, null,
                "deployment");
        }
        [Fact]
        public void CorrectRequestForDeleteAnApp() {
            var factory = Substitute.For<IConnection>();
            var client = new AppsClient(factory);

            client.DeleteAnApp("test");

            var parameters = Arg.Is<List<Parameter>>(list => (string) list[0].Value == "test");
            factory.Received().ExecuteRaw("apps/{appId}", parameters, null, Method.DELETE);
        }
    }
}
