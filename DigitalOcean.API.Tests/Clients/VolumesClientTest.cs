using System.Collections.Generic;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using NSubstitute;
using RestSharp;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class VolumesClientTest {
        [Fact]
        public void CorrectRequestForGetAll() {
            var factory = Substitute.For<IConnection>();
            var volumesClient = new VolumesClient(factory);

            volumesClient.GetAll();
            factory.Received().GetPaginated<Volume>("volumes", null, "volumes");
        }

        [Fact]
        public void CorrectRequestForCreate() {
            var factory = Substitute.For<IConnection>();
            var volumesClient = new VolumesClient(factory);

            var data = new Models.Requests.Volume();
            volumesClient.Create(data);
            factory.Received().ExecuteRequest<Volume>("volumes", null, data, "volume", Method.POST);
        }

        [Fact]
        public void CorrectRequestForGet() {
            var factory = Substitute.For<IConnection>();
            var volumesClient = new VolumesClient(factory);

            volumesClient.Get("id");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "id");
            factory.Received().ExecuteRequest<Volume>("volumes/{id}", parameters, null, "volume");
        }

        [Fact]
        public void CorrectRequestForGetByName() {
            var factory = Substitute.For<IConnection>();
            var volumesClient = new VolumesClient(factory);

            volumesClient.GetByName("name", "region");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "name" && (string)list[1].Value == "region");
            factory.Received().ExecuteRequest<Volume>("volumes", parameters, null, "volume");
        }

        [Fact]
        public void CorrectRequestForGetSnapshots() {
            var factory = Substitute.For<IConnection>();
            var volumesClient = new VolumesClient(factory);

            volumesClient.GetSnapshots("id");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "id");
            factory.Received().GetPaginated<Snapshot>("volumes/{id}/snapshots", parameters, "snapshots");
        }

        [Fact]
        public void CorrectRequestForCreateSnapshot() {
            var factory = Substitute.For<IConnection>();
            var volumesClient = new VolumesClient(factory);

            var snapshot = new Models.Requests.VolumeSnapshot();
            volumesClient.CreateSnapshot("id", snapshot);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "id");
            factory.Received().ExecuteRequest<Snapshot>("volumes/{id}/snapshots", parameters, snapshot, "snapshot", Method.POST);
        }

        [Fact]
        public void CorrectRequestForDelete() {
            var factory = Substitute.For<IConnection>();
            var volumesClient = new VolumesClient(factory);

            volumesClient.Delete("id");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "id");
            factory.Received().ExecuteRaw("volumes/{id}", parameters, null, Method.DELETE);
        }

        [Fact]
        public void CorrectRequestForDeleteByName() {
            var factory = Substitute.For<IConnection>();
            var volumesClient = new VolumesClient(factory);

            volumesClient.DeleteByName("name", "region");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "name" && (string)list[1].Value == "region");
            factory.Received().ExecuteRaw("volumes", parameters, null, Method.DELETE);
        }
    }
}
