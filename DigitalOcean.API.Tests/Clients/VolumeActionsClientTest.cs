using System.Collections.Generic;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using NSubstitute;
using RestSharp;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class VolumeActionsClientTest {
        [Fact]
        public void CorrectRequestForAttach() {
            var factory = Substitute.For<IConnection>();
            var volumeActionsClient = new VolumeActionsClient(factory);

            volumeActionsClient.Attach("id", 0, "nyc3");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "id");
            var body = Arg.Is<Models.Requests.VolumeAction>(action =>
                action.Type == "attach" &&
                action.DropletId == 0 &&
                action.Region == "nyc3");
            factory.Received().ExecuteRequest<Action>("volumes/{id}/actions", parameters, body, "action", Method.POST);
        }

        [Fact]
        public void CorrectRequestForAttachByName() {
            var factory = Substitute.For<IConnection>();
            var volumeActionsClient = new VolumeActionsClient(factory);

            volumeActionsClient.AttachByName("name", 0, "nyc3");

            var body = Arg.Is<Models.Requests.VolumeAction>(action =>
                action.Type == "attach" &&
                action.DropletId == 0 &&
                action.VolumeName == "name" &&
                action.Region == "nyc3");
            factory.Received().ExecuteRequest<Action>("volumes/actions", null, body, "action", Method.POST);
        }

        [Fact]
        public void CorrectRequestForDetach() {
            var factory = Substitute.For<IConnection>();
            var volumeActionsClient = new VolumeActionsClient(factory);

            volumeActionsClient.Detach("id", 0, "nyc3");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "id");
            var body = Arg.Is<Models.Requests.VolumeAction>(action =>
                action.Type == "detach" &&
                action.DropletId == 0 &&
                action.Region == "nyc3");
            factory.Received().ExecuteRequest<Action>("volumes/{id}/actions", parameters, body, "action", Method.POST);
        }

        [Fact]
        public void CorrectRequestForCreateDetachByName() {
            var factory = Substitute.For<IConnection>();
            var volumeActionsClient = new VolumeActionsClient(factory);

            volumeActionsClient.DetachByName("name", 0, "nyc3");

            var body = Arg.Is<Models.Requests.VolumeAction>(action =>
                action.Type == "detach" &&
                action.DropletId == 0 &&
                action.VolumeName == "name" &&
                action.Region == "nyc3");
            factory.Received().ExecuteRequest<Action>("volumes/actions", null, body, "action", Method.POST);
        }

        [Fact]
        public void CorrectRequestForResize() {
            var factory = Substitute.For<IConnection>();
            var volumeActionsClient = new VolumeActionsClient(factory);

            volumeActionsClient.Resize("id", 0, "nyc3");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "id");
            var body = Arg.Is<Models.Requests.VolumeAction>(action =>
                action.Type == "resize" &&
                action.SizeGigabytes == 0 &&
                action.Region == "nyc3");
            factory.Received().ExecuteRequest<Action>("volumes/{id}/actions", parameters, body, "action", Method.POST);
        }

        [Fact]
        public void CorrectRequestForGetActions() {
            var factory = Substitute.For<IConnection>();
            var volumeActionsClient = new VolumeActionsClient(factory);

            volumeActionsClient.GetActions("id");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "id");
            factory.Received().GetPaginated<Action>("volumes/{id}/actions", parameters, "action");
        }

        [Fact]
        public void CorrectRequestForGetAction() {
            var factory = Substitute.For<IConnection>();
            var volumeActionsClient = new VolumeActionsClient(factory);

            volumeActionsClient.GetAction("id", 0);
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "id" && (string)list[1].Value == 0.ToString());
            factory.Received().ExecuteRequest<Action>("volumes/{id}/actions/{actionId}", parameters, null, "action");
        }
    }
}
