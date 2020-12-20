using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Requests;
using DigitalOcean.API.Models.Responses;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalOcean.API.Clients {
    public interface IContainerRegistryClient {
        /// <summary>
        /// Configure your container registry.
        /// </summary>
        Task<Models.Responses.ContainerRegistryConfigure> Configure(Models.Requests.ContainerRegistryConfigure containerRegistryConfigure);

        /// <summary>
        /// Gets information for youre container registry.
        /// </summary>
        Task<ContainerRegistry> Get();

        /// <summary>
        /// Gets docker credentials for your container registry.
        /// </summary>
        Task<JObject> GetDockerCredentials();

        /// <summary>
        /// Gets your subscription information.
        /// </summary>
        Task<Subscription> GetSubscription();

        /// <summary>
        /// Updates your subscription tier.
        /// </summary>
        Task<SubscriptionTierUpdate> UpdateSubscriptionTier(UpdateSubscriptionTier updateSubscriptionTier);

        /// <summary>
        /// Deletes your container registry.
        /// </summary>
        Task Delete();

        /// <summary>
        /// Validates a container registry name.
        /// </summary>
        Task ValidateName(ContainerRegistryValidateName containerRegistryValidateName);

        /// <summary>
        /// Gets all of your container registry repositories.
        /// </summary>
        Task<IReadOnlyList<ContainerRegistryRepository>> GetAllRepositories(string registryName);

        /// <summary>
        /// Gets all of your container registry repository tags.
        /// </summary>
        Task<IReadOnlyList<ContainerRegistryTag>> GetAllRepositoryTags(string registryName, string repositoryName);

        /// <summary>
        /// Deletes a container registry repository tag.
        /// </summary>
        Task DeleteRepositoryTag(string registryName, string repositoryName, string tag);

        /// <summary>
        /// Deletes a container registry repository manifest.
        /// </summary>
        Task DeleteRepositoryManifest(string registryName, string repositoryName, string manifestDigest);

        /// <summary>
        /// Starts your container registry garbage collection.
        /// </summary>
        Task<GarbageCollection> StartGarbageCollection(string registryName);

        /// <summary>
        /// Gets your active container registry garbage collection.
        /// </summary>
        Task<GarbageCollection> GetActiveGarbageCollection(string registryName);

        /// <summary>
        /// Gets all your container registry garbage collections.
        /// </summary>
        Task<IReadOnlyList<GarbageCollection>> GetAllGarbageCollections(string registryName);

        /// <summary>
        /// Updates a container registry garbage collection.
        /// </summary>
        Task<GarbageCollection> UpdateGarbageCollection(string registryName, string uuid, UpdateGarbageCollection updateGarbageCollection);

        /// <summary>
        /// Gets all your available subscription tiers.
        /// </summary>
        Task<IReadOnlyList<SubscriptionTier>> GetAllSubscriptionTiers();
    }
}
