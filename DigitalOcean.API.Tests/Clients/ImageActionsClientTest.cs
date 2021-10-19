using System.Collections.Generic;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Requests;
using NSubstitute;
using RestSharp;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class ImageActionsClientTest {
        [Fact]
        public void CorrectRequestForTransfer() {
            var factory = Substitute.For<IConnection>();
            var client = new ImageActionsClient(factory);

            client.Transfer(9001, "sfo1");

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == 9001.ToString());
            var body = Arg.Is<ImageAction>(action => action.Type == "transfer" && action.Region == "sfo1");
            factory.Received().ExecuteRequest<Models.Responses.Action>("images/{imageId}/actions",
                parameters, body, "action", Method.POST);
        }

        [Fact]
        public void CorrectRequestForConvert() {
            var factory = Substitute.For<IConnection>();
            var client = new ImageActionsClient(factory);

            client.Convert(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == 9001.ToString());
            var body = Arg.Is<ImageAction>(action => action.Type == "convert");
            factory.Received().ExecuteRequest<Models.Responses.Action>("images/{imageId}/actions",
                parameters, body, "action", Method.POST);
        }

        [Fact]
        public void CorrectRequestForGetAction() {
            var factory = Substitute.For<IConnection>();
            var client = new ImageActionsClient(factory);

            client.GetAction(9001, 1009);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == 9001.ToString() &&
                                                             (string)list[1].Value == 1009.ToString());
            factory.Received().ExecuteRequest<Models.Responses.Action>("images/{imageId}/actions/{actionId}",
                parameters, null, "action");
        }
    }
}
