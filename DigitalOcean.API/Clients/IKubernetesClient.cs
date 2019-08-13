using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface IKubernetesClient {
        /// <summary>
        /// Create a new Kubernetes cluster
        /// </summary>
        Task<KubernetesCluster> Create(Models.Requests.KubernetesCluster cluster);

        /// <summary>
        /// Get an existing Kubernetes cluster
        /// </summary>
        Task<KubernetesCluster> Get(string clusterId);

        /// <summary>
        /// Get all existing Kubernetes clusters on your account
        /// </summary>
        Task<IReadOnlyList<KubernetesCluster>> GetAll();

        /// <summary>
        /// Update an exisiting Kubernetes cluster
        /// </summary>
        Task<KubernetesCluster> Update(string clusterId, Models.Requests.UpdateKubernetesCluster cluster);

        /// <summary>
        /// Retreive the upgrades available for a Kubernetes cluster
        /// </summary>
        Task<IReadOnlyList<KubernetesUpgrade>> GetUpgrades(string clusterId);

        /// <summary>
        /// Upgrade an existing Kubernetes cluster
        /// </summary>
        Task Upgrade(string clusterId, Models.Requests.KubernetesUpgrade upgrade);

        /// <summary>
        /// Delete an existing Kubernetes cluster
        /// </summary>
        Task Delete(string clusterId);

        /// <summary>
        /// Retreieve the kubeconfig file for a Kubernetes cluster
        /// </summary>
        /// <returns>
        /// Returns the YAML config response as a byte array
        /// </returns>
        Task<IReadOnlyList<byte>> GetKubeConfig(string clusterId);

        /// <summary>
        /// Retreive an existing node pool for a Kubernetes cluster
        /// </summary>
        Task<KubernetesNodePool> GetNodePool(string clusterId, string poolId);

        /// <summary>
        /// Retreive all existing node pools for a Kubernetes cluster
        /// </summary>
        Task<IReadOnlyList<KubernetesNodePool>> GetAllNodePools(string clusterId);

        /// <summary>
        /// Add a new node pool to a Kubernetes cluster
        /// </summary>
        Task<KubernetesNodePool> AddNodePool(string clusterId, Models.Requests.KubernetesNodePool pool);

        /// <summary>
        /// Update a node pool on an existing Kubernetes cluster
        /// </summary>
        Task<KubernetesNodePool> UpdateNodePool(string clusterId, string poolId, Models.Requests.UpdateKubernetesNodePool pool);

        /// <summary>
        /// Delete a node pool from a Kubernetes cluster
        /// </summary>
        Task DeleteNodePool(string clusterId, string poolId);

        /// <summary>
        /// Delete a node from a Kubernetes cluster
        /// </summary>
        Task DeleteNode(string clusterId, string poolId, string nodeId, Models.Requests.KubernetesNodeDeleteType type = Models.Requests.KubernetesNodeDeleteType.Drain);

        /// <summary>
        /// Get all available Kubernetes versions available for use
        /// </summary>
        Task<KubernetesOptions> GetOptions();
    }
}
