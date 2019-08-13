using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DigitalOcean.API.Extensions;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using RestSharp;

namespace DigitalOcean.API.Clients {
    public class KubernetesClient : IKubernetesClient {
        private readonly IConnection _connection;

        public KubernetesClient(IConnection connection) {
            _connection = connection;
        }

        #region IKubernetesClient Members

        /// <summary>
        /// Add a new node pool to a Kubernetes cluster
        /// </summary>
        public Task<KubernetesNodePool> AddNodePool(string clusterId, Models.Requests.KubernetesNodePool pool) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "id", Value = clusterId, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRequest<KubernetesNodePool>("kubernetes/clusters/{id}/node_pools", parameters, pool, "node_pool", Method.POST);
        }

        /// <summary>
        /// Create a new Kubernetes cluster
        /// </summary>
        public Task<KubernetesCluster> Create(Models.Requests.KubernetesCluster cluster) {
            return _connection.ExecuteRequest<KubernetesCluster>("kubernetes/clusters", null, cluster, "kubernetes_cluster", Method.POST);
        }

        /// <summary>
        /// Delete an existing Kubernetes cluster
        /// </summary>
        public Task Delete(string clusterId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "id", Value = clusterId, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRaw("kubernetes/clusters/{id}", parameters, null, Method.DELETE);
        }

        /// <summary>
        /// Delete a node from a Kubernetes cluster
        /// </summary>
        public Task DeleteNode(string clusterId, string poolId, string nodeId, Models.Requests.KubernetesNodeDeleteType type = Models.Requests.KubernetesNodeDeleteType.Drain) {
            var endpoint = "kubernetes/clusters/{id}/node_pools/{poolId}/nodes/{nodeId}";
            switch (type) {
                case Models.Requests.KubernetesNodeDeleteType.Drain:
                    break;
                case Models.Requests.KubernetesNodeDeleteType.SkipDrain:
                    endpoint = string.Format("{0}?skip_drain=1", endpoint);
                    break;
                case Models.Requests.KubernetesNodeDeleteType.Replace:
                    endpoint = string.Format("{0}?replace=1", endpoint);
                    break;
            }
            var parameters = new List<Parameter> {
                new Parameter { Name = "id", Value = clusterId, Type = ParameterType.UrlSegment },
                new Parameter { Name = "poolId", Value = poolId, Type = ParameterType.UrlSegment },
                new Parameter { Name = "nodeId", Value = nodeId, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRaw(endpoint, parameters, null, Method.DELETE);
        }

        /// <summary>
        /// Delete a node pool from a Kubernetes cluster
        /// </summary>
        public Task DeleteNodePool(string clusterId, string poolId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "id", Value = clusterId, Type = ParameterType.UrlSegment },
                new Parameter { Name = "poolId", Value = poolId, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRaw("kubernetes/clusters/{id}/node_pools/{poolId}", parameters, null, Method.DELETE);
        }

        /// <summary>
        /// Get an existing Kubernetes cluster
        /// </summary>
        public Task<KubernetesCluster> Get(string clusterId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "id", Value = clusterId, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRequest<KubernetesCluster>("kubernetes/clusters/{id}", parameters, null, "kubernetes_cluster");
        }

        /// <summary>
        /// Get all existing Kubernetes clusters on your account
        /// </summary>
        public Task<IReadOnlyList<KubernetesCluster>> GetAll() {
            return _connection.GetPaginated<KubernetesCluster>("kubernetes/clusters", null, "kubernetes_clusters");
        }

        /// <summary>
        /// Retreive all existing node pools for a Kubernetes cluster
        /// </summary>
        public Task<IReadOnlyList<KubernetesNodePool>> GetAllNodePools(string clusterId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "id", Value = clusterId, Type = ParameterType.UrlSegment }
            };
            return _connection.GetPaginated<KubernetesNodePool>("kubernetes/clusters/{id}/node_pools", parameters, "node_pools");
        }

        /// <summary>
        /// Retreieve the kubeconfig file for a Kubernetes cluster
        /// </summary>
        /// <returns>
        /// Returns the YAML kubeconfig response as a byte array
        /// </returns>
        public Task<IReadOnlyList<byte>> GetKubeConfig(string clusterId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "id", Value = clusterId, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRaw("kubernetes/clusters/{id}/kubeconfig", parameters, null).ToByteArrayAsync();
        }

        /// <summary>
        /// Retreive an existing node pool for a Kubernetes cluster
        /// </summary>
        public Task<KubernetesNodePool> GetNodePool(string clusterId, string poolId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "id", Value = clusterId, Type = ParameterType.UrlSegment },
                new Parameter { Name = "poolId", Value = poolId, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRequest<KubernetesNodePool>("kubernetes/clusters/{id}/node_pools/{poolId}", parameters, null, "node_pool");
        }

        /// <summary>
        /// Get all available Kubernetes versions available for use
        /// </summary>
        public Task<KubernetesOptions> GetOptions() {
            return _connection.ExecuteRequest<KubernetesOptions>("kubernetes/options", null, null, "options");
        }

        /// <summary>
        /// Retreive the upgrades available for a Kubernetes cluster
        /// </summary>
        public Task<IReadOnlyList<KubernetesUpgrade>> GetUpgrades(string clusterId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "id", Value = clusterId, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRequest<List<KubernetesUpgrade>>("kubernetes/clusters/{id}/upgrades", parameters, null, "available_upgrade_versions").ToReadOnlyListAsync();
        }

        /// <summary>
        /// Update an exisiting Kubernetes cluster
        /// </summary>
        public Task<KubernetesCluster> Update(string clusterId, Models.Requests.UpdateKubernetesCluster cluster) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "id", Value = clusterId, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRequest<KubernetesCluster>("kubernetes/clusters/{id}", parameters, cluster, "kubernetes_cluster", Method.PUT);
        }

        /// <summary>
        /// Update a node pool on an existing Kubernetes cluster
        /// </summary>
        public Task<KubernetesNodePool> UpdateNodePool(string clusterId, string poolId, Models.Requests.UpdateKubernetesNodePool pool) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "id", Value = clusterId, Type = ParameterType.UrlSegment },
                new Parameter { Name = "poolId", Value = poolId, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRequest<KubernetesNodePool>("kubernetes/clusters/{id}/node_pools/{poolId}", parameters, pool, "node_pool", Method.PUT);
        }

        /// <summary>
        /// Upgrade an existing Kubernetes cluster
        /// </summary>
        public Task Upgrade(string clusterId, Models.Requests.KubernetesUpgrade upgrade) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "id", Value = clusterId, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRaw("kubernetes/clusters/{id}/upgrade", parameters, upgrade, Method.POST);
        }

        #endregion
    }
}
