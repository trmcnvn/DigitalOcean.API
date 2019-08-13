using System.Collections.Generic;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using NSubstitute;
using RestSharp;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class KubernetesClientTest {
        [Fact]
        public void CorrectRequestForCreate() {
            var factory = Substitute.For<IConnection>();
            var client = new KubernetesClient(factory);
            var cluster = new Models.Requests.KubernetesCluster();
            client.Create(cluster);
            factory.Received().ExecuteRequest<KubernetesCluster>("kubernetes/clusters", null, cluster, "kubernetes_cluster", Method.POST);
        }

        [Fact]
        public void CorrectRequestForGet() {
            var factory = Substitute.For<IConnection>();
            var client = new KubernetesClient(factory);
            client.Get("1");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRequest<KubernetesCluster>("kubernetes/clusters/{id}", parameters, null, "kubernetes_cluster");
        }

        [Fact]
        public void CorrectRequestForGetAll() {
            var factory = Substitute.For<IConnection>();
            var client = new KubernetesClient(factory);
            client.GetAll();
            factory.Received().GetPaginated<KubernetesCluster>("kubernetes/clusters", null, "kubernetes_clusters");
        }

        [Fact]
        public void CorrectRequestForUpdate() {
            var factory = Substitute.For<IConnection>();
            var client = new KubernetesClient(factory);
            var update = new Models.Requests.UpdateKubernetesCluster();
            client.Update("1", update);
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRequest<KubernetesCluster>("kubernetes/clusters/{id}", parameters, update, "kubernetes_cluster", Method.PUT);
        }

        [Fact]
        public void CorrectRequestForGetUpgrades() {
            var factory = Substitute.For<IConnection>();
            var client = new KubernetesClient(factory);
            client.GetUpgrades("1");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRequest<List<KubernetesUpgrade>>("kubernetes/clusters/{id}/upgrades", parameters, null, "available_upgrade_versions");
        }

        [Fact]
        public void CorrectRequestForUpgrade() {
            var factory = Substitute.For<IConnection>();
            var client = new KubernetesClient(factory);
            var upgrade = new Models.Requests.KubernetesUpgrade();
            client.Upgrade("1", upgrade);
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRaw("kubernetes/clusters/{id}/upgrade", parameters, upgrade, Method.POST);
        }

        [Fact]
        public void CorrectRequestForDelete() {
            var factory = Substitute.For<IConnection>();
            var client = new KubernetesClient(factory);
            client.Delete("1");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRaw("kubernetes/clusters/{id}", parameters, null, Method.DELETE);
        }

        [Fact]
        public void CorrectRequestForGetKubeConfig() {
            var factory = Substitute.For<IConnection>();
            var client = new KubernetesClient(factory);
            client.GetKubeConfig("1");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRaw("kubernetes/clusters/{id}/kubeconfig", parameters, null, Method.GET);
        }

        [Fact]
        public void CorrectRequestForGetNodePool() {
            var factory = Substitute.For<IConnection>();
            var client = new KubernetesClient(factory);
            client.GetNodePool("1", "2");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1" && (string)list[1].Value == "2");
            factory.Received().ExecuteRequest<KubernetesNodePool>("kubernetes/clusters/{id}/node_pools/{poolId}", parameters, null, "node_pool");
        }

        [Fact]
        public void CorrectRequestForGetAllNodePools() {
            var factory = Substitute.For<IConnection>();
            var client = new KubernetesClient(factory);
            client.GetAllNodePools("1");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().GetPaginated<KubernetesNodePool>("kubernetes/clusters/{id}/node_pools", parameters, "node_pools");
        }

        [Fact]
        public void CorrectRequestForAddNodePool() {
            var factory = Substitute.For<IConnection>();
            var client = new KubernetesClient(factory);
            var pool = new Models.Requests.KubernetesNodePool();
            client.AddNodePool("1", pool);
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRequest<KubernetesNodePool>("kubernetes/clusters/{id}/node_pools", parameters, pool, "node_pool", Method.POST);
        }

        [Fact]
        public void CorrectRequestForUpdateNodePool() {
            var factory = Substitute.For<IConnection>();
            var client = new KubernetesClient(factory);
            var pool = new Models.Requests.UpdateKubernetesNodePool();
            client.UpdateNodePool("1", "2", pool);
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1" && (string)list[1].Value == "2");
            factory.Received().ExecuteRequest<KubernetesNodePool>("kubernetes/clusters/{id}/node_pools/{poolId}", parameters, pool, "node_pool", Method.PUT);
        }

        [Fact]
        public void CorrectRequestForDeleteNodePool() {
            var factory = Substitute.For<IConnection>();
            var client = new KubernetesClient(factory);
            client.DeleteNodePool("1", "2");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1" && (string)list[1].Value == "2");
            factory.Received().ExecuteRaw("kubernetes/clusters/{id}/node_pools/{poolId}", parameters, null, Method.DELETE);
        }

        [Fact]
        public void CorrectRequestForGetOptions() {
            var factory = Substitute.For<IConnection>();
            var client = new KubernetesClient(factory);
            client.GetOptions();
            factory.Received().ExecuteRequest<KubernetesOptions>("kubernetes/options", null, null, "options");
        }
    }
}
