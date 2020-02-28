using System.Collections.Generic;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using NSubstitute;
using RestSharp;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class FirewallsClientTest {
        [Fact]
        public void CorrectRequestForCreate() {
            var factory = Substitute.For<IConnection>();
            var client = new FirewallsClient(factory);

            var firewall = new Models.Requests.Firewall();
            client.Create(firewall);
            factory.Received().ExecuteRequest<Firewall>("firewalls", null, firewall, "firewall", Method.POST);
        }

        [Fact]
        public void CorrectRequestForGet() {
            var factory = Substitute.For<IConnection>();
            var client = new FirewallsClient(factory);
            client.Get("1");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRequest<Firewall>("firewalls/{id}", parameters, null, "firewall");
        }

        [Fact]
        public void CorrectRequestForGetAll() {
            var factory = Substitute.For<IConnection>();
            var client = new FirewallsClient(factory);
            client.GetAll();
            factory.Received().GetPaginated<Firewall>("firewalls", null, "firewalls");
        }

        [Fact]
        public void CorrectRequestForUpdate() {
            var factory = Substitute.For<IConnection>();
            var client = new FirewallsClient(factory);
            var firewall = new Models.Requests.Firewall();
            client.Update("1", firewall);
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRequest<Firewall>("firewalls/{id}", parameters, firewall, "firewall", Method.PUT);
        }

        [Fact]
        public void CorrectRequestForDelete() {
            var factory = Substitute.For<IConnection>();
            var client = new FirewallsClient(factory);
            client.Delete("1");
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRaw("firewalls/{id}", parameters, null, Method.DELETE);
        }

        [Fact]
        public void CorrectRequestForAddDroplets() {
            var factory = Substitute.For<IConnection>();
            var client = new FirewallsClient(factory);
            var droplets = new Models.Requests.FirewallDroplets {
                DropletIds = new List<long> { 1, 2, 3, 4 }
            };
            client.AddDroplets("1", droplets);
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRaw("firewalls/{id}/droplets", parameters, droplets, Method.POST);
        }

        [Fact]
        public void CorrectRequestForRemoveDroplets() {
            var factory = Substitute.For<IConnection>();
            var client = new FirewallsClient(factory);
            var droplets = new Models.Requests.FirewallDroplets {
                DropletIds = new List<long> { 1, 2, 3, 4 }
            };
            client.RemoveDroplets("1", droplets);
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRaw("firewalls/{id}/droplets", parameters, droplets, Method.DELETE);
        }

        [Fact]
        public void CorrectRequestForAddTags() {
            var factory = Substitute.For<IConnection>();
            var client = new FirewallsClient(factory);
            var tags = new Models.Requests.FirewallTags {
                Tags = new List<string> { "awesome" }
            };
            client.AddTags("1", tags);
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRaw("firewalls/{id}/tags", parameters, tags, Method.POST);
        }

        [Fact]
        public void CorrectRequestForRemoveTags() {
            var factory = Substitute.For<IConnection>();
            var client = new FirewallsClient(factory);
            var tags = new Models.Requests.FirewallTags {
                Tags = new List<string> { "awesome" }
            };
            client.RemoveTags("1", tags);
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRaw("firewalls/{id}/tags", parameters, tags, Method.DELETE);
        }

        [Fact]
        public void CorrectRequestForAddRules() {
            var factory = Substitute.For<IConnection>();
            var client = new FirewallsClient(factory);
            var rules = new Models.Requests.FirewallRules {
                InboundRules = new List<Models.Requests.InboundRule> {
                    new Models.Requests.InboundRule()
                },
                OutboundRules = new List<Models.Requests.OutboundRule> {
                    new Models.Requests.OutboundRule()
                }
            };
            client.AddRules("1", rules);
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRaw("firewalls/{id}/rules", parameters, rules, Method.POST);
        }

        [Fact]
        public void CorrectRequestForRemoveRules() {
            var factory = Substitute.For<IConnection>();
            var client = new FirewallsClient(factory);
            var rules = new Models.Requests.FirewallRules {
                InboundRules = new List<Models.Requests.InboundRule> {
                    new Models.Requests.InboundRule()
                },
                OutboundRules = new List<Models.Requests.OutboundRule> {
                    new Models.Requests.OutboundRule()
                }
            };
            client.RemoveRules("1", rules);
            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "1");
            factory.Received().ExecuteRaw("firewalls/{id}/rules", parameters, rules, Method.DELETE);
        }
    }
}
