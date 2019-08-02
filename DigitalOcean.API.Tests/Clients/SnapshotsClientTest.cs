using System.Collections.Generic;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using NSubstitute;
using RestSharp;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class SnapshotsClientTest {
        [Fact]
        public void CorrectRequestForGetAll() {
            var factory = Substitute.For<IConnection>();
            var client = new SnapshotsClient(factory);

            client.GetAll();
            factory.Received().GetPaginated<Snapshot>("snapshots", null, "snapshots");
        }

        [Fact]
        public void CorrectRequestForGetAllDroplet() {
            var factory = Substitute.For<IConnection>();
            var client = new SnapshotsClient(factory);

            client.GetAllDroplet();
            factory.Received().GetPaginated<Snapshot>("snapshots?resource_type=droplet", null, "snapshots");
        }

        [Fact]
        public void CorrectRequestForGetAllVolume() {
            var factory = Substitute.For<IConnection>();
            var client = new SnapshotsClient(factory);

            client.GetAllVolume();
            factory.Received().GetPaginated<Snapshot>("snapshots?resource_type=volume", null, "snapshots");
        }

        [Fact]
        public void CorrectRequestForGet() {
            var factory = Substitute.For<IConnection>();
            var client = new SnapshotsClient(factory);

            client.Get("snapshot:abc123");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "snapshot:abc123");
            factory.Received().ExecuteRequest<Snapshot>("snapshots/{snapshot_id}", parameters, null, "snapshot");
        }

        [Fact]
        public void CorrectRequestForDelete() {
            var factory = Substitute.For<IConnection>();
            var client = new SnapshotsClient(factory);

            client.Delete("snapshot:abc123");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "snapshot:abc123");
            factory.Received().ExecuteRaw("snapshots/{snapshot_id}", parameters, null, Method.DELETE);
        }

    }
}
