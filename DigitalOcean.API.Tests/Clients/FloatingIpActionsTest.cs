using System.Collections.Generic;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using NSubstitute;
using RestSharp;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class FloatingIpActionsTest {
        [Fact]
        public void CorrectRequestForAssign() {
            var factory = Substitute.For<IConnection>();
            var client = new FloatingIpActionsClient(factory);

            client.Assign("1.2.3.4", 0);
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1.2.3.4");
            var body = Arg.Is<Models.Requests.FloatingIpAction>(action =>
                action.Type == "assign" && action.DropletId == 0);
            factory.Received().ExecuteRequest<Action>("floating_ips/{ip}/actions", parameters, body, "action", Method.Post);
        }

        [Fact]
        public void CorrectRequestForUnassign() {
            var factory = Substitute.For<IConnection>();
            var client = new FloatingIpActionsClient(factory);

            client.Unassign("1.2.3.4");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1.2.3.4");
            var body = Arg.Is<Models.Requests.FloatingIpAction>(action => action.Type == "unassign");
            factory.Received().ExecuteRequest<Action>("floating_ips/{ip}/actions", parameters, body, "action", Method.Post);
        }

        [Fact]
        public void CorrectRequestForGetActions() {
            var factory = Substitute.For<IConnection>();
            var client = new FloatingIpActionsClient(factory);

            client.GetActions("1.2.3.4");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1.2.3.4");
            factory.Received().GetPaginated<Action>("floating_ips/{ip}/actions", parameters, "actions");
        }

        [Fact]
        public void CorrectRequestForAction() {
            var factory = Substitute.For<IConnection>();
            var client = new FloatingIpActionsClient(factory);

            client.GetAction("1.2.3.4", 100);
            var parameters = Arg.Is<List<Parameter>>(list =>
                (string)list[0].Value == "1.2.3.4" && (string)list[1].Value == 100.ToString());
            factory.Received().ExecuteRequest<Action>("floating_ips/{ip}/actions/{actionId}", parameters, null, "action");
        }
    }
}
