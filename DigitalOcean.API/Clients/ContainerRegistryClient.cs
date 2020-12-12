using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Requests;
using DigitalOcean.API.Models.Responses;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalOcean.API.Clients {
    public class ContainerRegistryClient : IContainerRegistryClient {
        private readonly IConnection _connection;

        public ContainerRegistryClient(IConnection connection) {
            _connection = connection;
        }

        /// <summary>
        /// Configure your container registry.
        /// </summary>
        public Task<Models.Responses.ContainerRegistryConfigure> Configure(Models.Requests.ContainerRegistryConfigure containerRegistryConfigure) {
            return _connection.ExecuteRequest<Models.Responses.ContainerRegistryConfigure>("registry", null, containerRegistryConfigure, null, Method.POST);
        }

        /// <summary>
        /// Gets information for youre container registry.
        /// </summary>
        public Task<ContainerRegistry> Get() {
            return _connection.ExecuteRequest<ContainerRegistry>("registry", null, null, "registry");
        }

        /// <summary>
        /// Gets docker credentials for your container registry.
        /// </summary>
        public Task<JObject> GetDockerCredentials() {
            return _connection.ExecuteRequest<JObject>("registry/docker-credentials", null, null, "auths");
        }

        /// <summary>
        /// Gets your subscription information.
        /// </summary>
        public Task<Subscription> GetSubscription() {
            return _connection.ExecuteRequest<Subscription>("registry/subscription", null, null, "subscription");
        }

        /// <summary>
        /// Updates your subscription tier.
        /// </summary>
        public Task<SubscriptionTierUpdate> UpdateSubscriptionTier(UpdateSubscriptionTier updateSubscriptionTier) {
            return _connection.ExecuteRequest<SubscriptionTierUpdate>("registry/subscription", null, updateSubscriptionTier, "subscription", Method.POST);
        }

        /// <summary>
        /// Deletes your container registry.
        /// </summary>
        public Task Delete() {
            return _connection.ExecuteRaw("registry", null, null, Method.DELETE);
        }

        /// <summary>
        /// Validates a container registry name.
        /// </summary>
        public Task ValidateName(ContainerRegistryValidateName containerRegistryValidateName) {
            return _connection.ExecuteRaw("registry/validate-name", null, containerRegistryValidateName, Method.POST);
        }

        /// <summary>
        /// Gets all of your container registry repositories.
        /// </summary>
        public Task<IReadOnlyList<ContainerRegistryRepository>> GetAllRepositories(string registryName) {
            var parameters = new List<Parameter> {
                new Parameter(nameof(registryName), registryName, ParameterType.UrlSegment)
            };

            return _connection.GetPaginated<ContainerRegistryRepository>($"registry/{{{nameof(registryName)}}}/repositories", parameters, "repositories");
        }

        /// <summary>
        /// Gets all of your container registry repository tags.
        /// </summary>
        public Task<IReadOnlyList<ContainerRegistryTag>> GetAllRepositoryTags(string registryName, string repositoryName) {
            var parameters = new List<Parameter> {
                new Parameter(nameof(registryName), registryName, ParameterType.UrlSegment),
                new Parameter(nameof(repositoryName), repositoryName, ParameterType.UrlSegment),
            };

            return _connection.GetPaginated<ContainerRegistryTag>($"registry/{{{nameof(registryName)}}}/repositories/{{{nameof(repositoryName)}}}/tags", parameters, "tags");
        }

        /// <summary>
        /// Deletes a container registry repository tag.
        /// </summary>
        public Task DeleteRepositoryTag(string registryName, string repositoryName, string tag) {
            var parameters = new List<Parameter> {
                new Parameter(nameof(registryName), registryName, ParameterType.UrlSegment),
                new Parameter(nameof(repositoryName), repositoryName, ParameterType.UrlSegment),
                new Parameter(nameof(tag), tag, ParameterType.UrlSegment),
            };

            return _connection.ExecuteRaw($"registry/{{{nameof(registryName)}}}/repositories/{{{nameof(repositoryName)}}}/tags/{{{nameof(tag)}}}", parameters, null, Method.DELETE);
        }

        /// <summary>
        /// Deletes a container registry repository manifest.
        /// </summary>
        public Task DeleteRepositoryManifest(string registryName, string repositoryName, string manifestDigest) {
            var parameters = new List<Parameter> {
                new Parameter(nameof(registryName), registryName, ParameterType.UrlSegment),
                new Parameter(nameof(repositoryName), repositoryName, ParameterType.UrlSegment),
                new Parameter(nameof(manifestDigest), manifestDigest, ParameterType.UrlSegment),
            };

            return _connection.ExecuteRaw($"registry/{{{nameof(registryName)}}}/repositories/{{{nameof(repositoryName)}}}/digests/{{{nameof(manifestDigest)}}}", parameters, null, Method.DELETE);
        }

        /// <summary>
        /// Starts your container registry garbage collection.
        /// </summary>
        public Task<GarbageCollection> StartGarbageCollection(string registryName) {
            var parameters = new List<Parameter> {
                new Parameter(nameof(registryName), registryName, ParameterType.UrlSegment),
            };

            return _connection.ExecuteRequest<GarbageCollection>($"registry/{{{nameof(registryName)}}}/garbage-collection", parameters, null, "garbage_collections", Method.POST);
        }

        /// <summary>
        /// Gets your active container registry garbage collection.
        /// </summary>
        public Task<GarbageCollection> GetActiveGarbageCollection(string registryName) {
            var parameters = new List<Parameter> {
                new Parameter(nameof(registryName), registryName, ParameterType.UrlSegment),
            };

            return _connection.ExecuteRequest<GarbageCollection>($"registry/{{{nameof(registryName)}}}/garbage-collection", parameters, null, "garbage_collections");
        }

        /// <summary>
        /// Gets all your container registry garbage collections.
        /// </summary>
        public Task<IReadOnlyList<GarbageCollection>> GetAllGarbageCollections(string registryName) {
            var parameters = new List<Parameter> {
                new Parameter(nameof(registryName), registryName, ParameterType.UrlSegment),
            };

            return _connection.GetPaginated<GarbageCollection>($"registry/{{{nameof(registryName)}}}/garbage-collections", parameters, "garbage_collections");
        }

        /// <summary>
        /// Updates a container registry garbage collection.
        /// </summary>
        public Task<GarbageCollection> UpdateGarbageCollection(string registryName, string uuid, UpdateGarbageCollection updateGarbageCollection) {
            var parameters = new List<Parameter> {
                new Parameter(nameof(registryName), registryName, ParameterType.UrlSegment),
                new Parameter(nameof(uuid), uuid, ParameterType.UrlSegment),
            };

            return _connection.ExecuteRequest<GarbageCollection>($"registry/{{{nameof(registryName)}}}/garbage-collection/{{{nameof(uuid)}}}", parameters, updateGarbageCollection, "garbage_collections", Method.PUT);
        }

        /// <summary>
        /// Gets all your available subscription tiers.
        /// </summary>
        public Task<IReadOnlyList<SubscriptionTier>> GetAllSubscriptionTiers() {
            return _connection.GetPaginated<SubscriptionTier>($"registry/options", null, "subscription_tiers");
        }
    }
}
