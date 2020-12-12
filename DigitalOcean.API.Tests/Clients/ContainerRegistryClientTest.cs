using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Requests;
using DigitalOcean.API.Models.Responses;
using Newtonsoft.Json.Linq;
using NSubstitute;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class ContainerRegistryClientTest {
        [Fact]
        public void CorrectRequestForConfigure() {
            var factory = Substitute.For<IConnection>();
            var client = new ContainerRegistryClient(factory);

            var data = new Models.Requests.ContainerRegistryConfigure();
            client.Configure(data);
            factory.Received().ExecuteRequest<Models.Responses.ContainerRegistryConfigure>("registry", null, data, null, Method.POST);
        }

        [Fact]
        public void CorrectRequestForGet() {
            var factory = Substitute.For<IConnection>();
            var client = new ContainerRegistryClient(factory);

            client.Get();
            factory.Received().ExecuteRequest<ContainerRegistry>("registry", null, null, "registry");
        }

        [Fact]
        public void CorrectRequestForGetDockerCredentials() {
            var factory = Substitute.For<IConnection>();
            var client = new ContainerRegistryClient(factory);

            client.GetDockerCredentials();
            factory.Received().ExecuteRequest<JObject>("registry/docker-credentials", null, null, "auths");
        }

        [Fact]
        public void CorrectRequestForGetSubscription() {
            var factory = Substitute.For<IConnection>();
            var client = new ContainerRegistryClient(factory);

            client.GetSubscription();
            factory.Received().ExecuteRequest<Subscription>("registry/subscription", null, null, "subscription");
        }

        [Fact]
        public void CorrectRequestForUpdateSubscriptionTier() {
            var factory = Substitute.For<IConnection>();
            var client = new ContainerRegistryClient(factory);

            var data = new UpdateSubscriptionTier();
            client.UpdateSubscriptionTier(data);
            factory.Received().ExecuteRequest<SubscriptionTierUpdate>("registry/subscription", null, data, "subscription", Method.POST);
        }

        [Fact]
        public void CorrectRequestForDelete() {
            var factory = Substitute.For<IConnection>();
            var client = new ContainerRegistryClient(factory);

            client.Delete();
            factory.Received().ExecuteRaw("registry", null, null, Method.DELETE);
        }

        [Fact]
        public void CorrectRequestForValidateName() {
            var factory = Substitute.For<IConnection>();
            var client = new ContainerRegistryClient(factory);

            var data = new ContainerRegistryValidateName();
            client.ValidateName(data);
            factory.Received().ExecuteRaw("registry/validate-name", null, data, Method.POST);
        }

        [Fact]
        public void CorrectRequestForGetAllRepositories() {
            var factory = Substitute.For<IConnection>();
            var client = new ContainerRegistryClient(factory);

            client.GetAllRepositories("registryName");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "registryName");
            factory.Received().GetPaginated<ContainerRegistryRepository>("registry/{registryName}/repositories", parameters, "repositories");
        }

        [Fact]
        public void CorrectRequestForGetAllRepositoryTags() {
            var factory = Substitute.For<IConnection>();
            var client = new ContainerRegistryClient(factory);

            client.GetAllRepositoryTags("registryName", "repositoryName");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "registryName" && (string)list[1].Value == "repositoryName");
            factory.Received().GetPaginated<ContainerRegistryTag>("registry/{registryName}/repositories/{repositoryName}/tags", parameters, "tags");
        }

        [Fact]
        public void CorrectRequestForDeleteRepositoryTag() {
            var factory = Substitute.For<IConnection>();
            var client = new ContainerRegistryClient(factory);

            client.DeleteRepositoryTag("registryName", "repositoryName", "tag");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "registryName" && (string)list[1].Value == "repositoryName" && (string)list[2].Value == "tag");
            factory.Received().ExecuteRaw("registry/{registryName}/repositories/{repositoryName}/tags/{tag}", parameters, null, Method.DELETE);
        }

        [Fact]
        public void CorrectRequestForDeleteRepositoryManifest() {
            var factory = Substitute.For<IConnection>();
            var client = new ContainerRegistryClient(factory);

            client.DeleteRepositoryManifest("registryName", "repositoryName", "manifestDigest");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "registryName" && (string)list[1].Value == "repositoryName" && (string)list[2].Value == "manifestDigest");
            factory.Received().ExecuteRaw("registry/{registryName}/repositories/{repositoryName}/digests/{manifestDigest}", parameters, null, Method.DELETE);
        }

        [Fact]
        public void CorrectRequestForStartGarbageCollection() {
            var factory = Substitute.For<IConnection>();
            var client = new ContainerRegistryClient(factory);

            client.StartGarbageCollection("registryName");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "registryName");
            factory.Received().ExecuteRequest<GarbageCollection>("registry/{registryName}/garbage-collection", parameters, null, "garbage_collections", Method.POST);
        }

        [Fact]
        public void CorrectRequestForGetActiveGarbageCollection() {
            var factory = Substitute.For<IConnection>();
            var client = new ContainerRegistryClient(factory);

            client.GetActiveGarbageCollection("registryName");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "registryName");
            factory.Received().ExecuteRequest<GarbageCollection>("registry/{registryName}/garbage-collection", parameters, null, "garbage_collections");
        }

        [Fact]
        public void CorrectRequestForGetAllGarbageCollections() {
            var factory = Substitute.For<IConnection>();
            var client = new ContainerRegistryClient(factory);

            client.GetAllGarbageCollections("registryName");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "registryName");
            factory.Received().GetPaginated<GarbageCollection>("registry/{registryName}/garbage-collections", parameters, "garbage_collections");
        }

        [Fact]
        public void CorrectRequestForUpdateGarbageCollection() {
            var factory = Substitute.For<IConnection>();
            var client = new ContainerRegistryClient(factory);

            var data = new UpdateGarbageCollection();
            client.UpdateGarbageCollection("registryName", "uuid", data);
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "registryName" && (string)list[1].Value == "uuid");
            factory.Received().ExecuteRequest<GarbageCollection>("registry/{registryName}/garbage-collection/{uuid}", parameters, data, "garbage_collections", Method.PUT);
        }

        [Fact]
        public void CorrectRequestForGetAllSubscriptionTiers() {
            var factory = Substitute.For<IConnection>();
            var client = new ContainerRegistryClient(factory);

            client.GetAllSubscriptionTiers();
            factory.Received().GetPaginated<SubscriptionTier>("registry/options", null, "subscription_tiers");
        }
    }
}
