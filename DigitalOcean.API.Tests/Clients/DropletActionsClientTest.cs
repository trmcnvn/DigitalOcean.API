using System;
using System.Collections.Generic;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Requests;
using NSubstitute;
using RestSharp;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class DropletActionsClientTest {
        [Fact]
        public void CorrectRequestForReboot() {
                var factory = Substitute.For<IConnection>();
            var client = new DropletActionsClient(factory);

            client.Reboot(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            var body = Arg.Is<DropletAction>(action => action.Type == "reboot");
            factory.Received().ExecuteRequest<Models.Responses.Action>("droplets/{dropletId}/actions",
                parameters, body, "action", Method.POST);
        }

        [Fact]
        public void CorrectRequestForPowerCycle() {
                var factory = Substitute.For<IConnection>();
            var client = new DropletActionsClient(factory);

            client.PowerCycle(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            var body = Arg.Is<DropletAction>(action => action.Type == "power_cycle");
            factory.Received().ExecuteRequest<Models.Responses.Action>("droplets/{dropletId}/actions",
                parameters, body, "action", Method.POST);
        }

        [Fact]
        public void CorrectRequestForShutdown() {
                var factory = Substitute.For<IConnection>();
            var client = new DropletActionsClient(factory);

            client.Shutdown(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            var body = Arg.Is<DropletAction>(action => action.Type == "shutdown");
            factory.Received().ExecuteRequest<Models.Responses.Action>("droplets/{dropletId}/actions",
                parameters, body, "action", Method.POST);
        }

        [Fact]
        public void CorrectRequestForPowerOff() {
                var factory = Substitute.For<IConnection>();
            var client = new DropletActionsClient(factory);

            client.PowerOff(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            var body = Arg.Is<DropletAction>(action => action.Type == "power_off");
            factory.Received().ExecuteRequest<Models.Responses.Action>("droplets/{dropletId}/actions",
                parameters, body, "action", Method.POST);
        }

        [Fact]
        public void CorrectRequestForPowerOn() {
                var factory = Substitute.For<IConnection>();
            var client = new DropletActionsClient(factory);

            client.PowerOn(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            var body = Arg.Is<DropletAction>(action => action.Type == "power_on");
            factory.Received().ExecuteRequest<Models.Responses.Action>("droplets/{dropletId}/actions",
                parameters, body, "action", Method.POST);
        }

        [Fact]
        public void CorrectRequestForResetPassword() {
                var factory = Substitute.For<IConnection>();
            var client = new DropletActionsClient(factory);

            client.ResetPassword(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            var body = Arg.Is<DropletAction>(action => action.Type == "password_reset");
            factory.Received().ExecuteRequest<Models.Responses.Action>("droplets/{dropletId}/actions",
                parameters, body, "action", Method.POST);
        }

        [Fact]
        public void CorrectRequestForResize() {
                var factory = Substitute.For<IConnection>();
            var client = new DropletActionsClient(factory);

            client.Resize(9001, "1024mb");

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            var body = Arg.Is<DropletAction>(action => action.Type == "resize" && action.SizeSlug == "1024mb");
            factory.Received().ExecuteRequest<Models.Responses.Action>("droplets/{dropletId}/actions",
                parameters, body, "action", Method.POST);
        }

        [Fact]
        public void CorrectRequestForRestore() {
                var factory = Substitute.For<IConnection>();
            var client = new DropletActionsClient(factory);

            client.Restore(9001, 1009);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            var body = Arg.Is<DropletAction>(action => action.Type == "restore" && (int)action.ImageIdOrSlug == 1009);
            factory.Received().ExecuteRequest<Models.Responses.Action>("droplets/{dropletId}/actions",
                parameters, body, "action", Method.POST);
        }

        [Fact]
        public void CorrectRequestForRebuild() {
                var factory = Substitute.For<IConnection>();
            var client = new DropletActionsClient(factory);

            client.Rebuild(9001, 1009);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            var body = Arg.Is<DropletAction>(action => action.Type == "rebuild" && (int)action.ImageIdOrSlug == 1009);
            factory.Received().ExecuteRequest<Models.Responses.Action>("droplets/{dropletId}/actions",
                parameters, body, "action", Method.POST);
        }

        [Fact]
        public void CorrectRequestForRename() {
                var factory = Substitute.For<IConnection>();
            var client = new DropletActionsClient(factory);

            client.Rename(9001, "testing");

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            var body = Arg.Is<DropletAction>(action => action.Type == "rename" && action.Name == "testing");
            factory.Received().ExecuteRequest<Models.Responses.Action>("droplets/{dropletId}/actions",
                parameters, body, "action", Method.POST);
        }

        [Fact]
        public void CorrectRequestForKernel() {
            var factory = Substitute.For<IConnection>();
            var client = new DropletActionsClient(factory);

            client.ChangeKernel(9001, 1009);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            var body = Arg.Is<DropletAction>(action => action.Type == "change_kernel" && action.KernelId == 1009);
            factory.Received().ExecuteRequest<Models.Responses.Action>("droplets/{dropletId}/actions",
                parameters, body, "action", Method.POST);
        }

        [Fact]
        public void CorrectRequestForIpv6() {
                var factory = Substitute.For<IConnection>();
            var client = new DropletActionsClient(factory);

            client.EnableIpv6(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            var body = Arg.Is<DropletAction>(action => action.Type == "enable_ipv6");
            factory.Received().ExecuteRequest<Models.Responses.Action>("droplets/{dropletId}/actions",
                parameters, body, "action", Method.POST);
        }

        [Fact]
        public void CorrectRequestForBackups() {
                var factory = Substitute.For<IConnection>();
            var client = new DropletActionsClient(factory);

            client.DisableBackups(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            var body = Arg.Is<DropletAction>(action => action.Type == "disable_backups");
            factory.Received().ExecuteRequest<Models.Responses.Action>("droplets/{dropletId}/actions",
                parameters, body, "action", Method.POST);
        }

        [Fact]
        public void CorrectRequestForPrivateNetworking() {
               var factory = Substitute.For<IConnection>();
            var client = new DropletActionsClient(factory);

            client.EnablePrivateNetworking(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            var body = Arg.Is<DropletAction>(action => action.Type == "enable_private_networking");
            factory.Received().ExecuteRequest<Models.Responses.Action>("droplets/{dropletId}/actions",
                parameters, body, "action", Method.POST);
        }

        [Fact]
        public void CorrectRequestForSnapshot() {
                var factory = Substitute.For<IConnection>();
            var client = new DropletActionsClient(factory);

            client.Snapshot(9001, "testing");

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            var body = Arg.Is<DropletAction>(action => action.Type == "snapshot" && action.Name == "testing");
            factory.Received().ExecuteRequest<Models.Responses.Action>("droplets/{dropletId}/actions",
                parameters, body, "action", Method.POST);
        }

        [Fact]
        public void CorrectRequestForGetAction() {
                var factory = Substitute.For<IConnection>();
            var client = new DropletActionsClient(factory);

            client.GetDropletAction(9001, 1009);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001 &&
                (int)list[1].Value == 1009);
            factory.Received().ExecuteRequest<Models.Responses.Action>("droplets/{dropletId}/actions/{actionId}",
                parameters, null, "action");
        }
    }
}
