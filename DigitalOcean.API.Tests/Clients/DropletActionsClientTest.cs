using System;
using System.Collections.Generic;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using NSubstitute;
using RestSharp;
using Xunit;
using Action = DigitalOcean.API.Models.Requests.Action;

namespace DigitalOcean.API.Tests.Clients {
    public class DropletActionsClientTest {
        [Fact]
        public void CorrectRequestForAction() {
            var factory = Substitute.For<IConnection>();
            var client = new DropletActionsClient(factory);

            client.Reboot(9001);
            client.PowerCycle(9001);
            client.Shutdown(9001);
            client.PowerOff(9001);
            client.PowerOn(9001);
            client.ResetPassword(9001);
            client.Resize(9001, "1024mb");
            client.Restore(9001, 1009);
            client.Rename(9001, "testing");
            client.ChangeKernel(9001, 1009);
            client.DisableBackups(9001);
            client.EnablePrivateNetworking(9001);
            client.Snapshot(9001, "testing");

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            var body = Arg.Is<Action>(action => !String.IsNullOrWhiteSpace(action.Type));
            factory.Received(13).ExecuteRequest<Models.Responses.Action>("droplets/{dropletId}/actions",
                parameters, body, "action", Method.POST);
        }
    }
}