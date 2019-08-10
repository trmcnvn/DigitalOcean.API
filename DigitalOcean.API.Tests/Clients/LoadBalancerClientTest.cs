using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Requests;
using NSubstitute;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
	public class LoadBalancerClientTest {
		[Fact]
		public void CorrectRequestForGetAll() {
			var factory = Substitute.For<IConnection>();
			var client = new LoadBalancerClient(factory);

			client.GetAll();

			factory.Received().GetPaginated<Models.Responses.LoadBalancer>("load_balancers", null, "load_balancers");
		}

		[Fact]
		public void CorrectRequestForCreate() {
			var factory = Substitute.For<IConnection>();
			var client = new LoadBalancerClient(factory);

			var body = new LoadBalancer();
			client.Create(body);

			factory.Received().ExecuteRequest<Models.Responses.LoadBalancer>("load_balancers", null, body, "load_balancers", Method.POST);
		}

		[Fact]
		public void CorrectRequestForDelete() {
			var factory = Substitute.For<IConnection>();
			var client = new LoadBalancerClient(factory);

			client.Delete("10");

			var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "10");
			factory.Received().ExecuteRaw("load_balancers/{id}", null, parameters, Method.DELETE);
		}

		[Fact]
		public void CorrectRequestForGet() {
			var factory = Substitute.For<IConnection>();
			var client = new LoadBalancerClient(factory);

			client.Get("15");

			var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "15");
			factory.Received().ExecuteRequest<Models.Responses.LoadBalancer>("load_balancers/{id}", null, parameters, "load_balancers", Method.GET);
		}

		[Fact]
		public void CorrectRequestForUpdate() {
			var factory = Substitute.For<IConnection>();
			var client = new LoadBalancerClient(factory);

			var body = new LoadBalancer();
			client.Update("15",body);

			var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "15");
			factory.Received().ExecuteRequest<Models.Responses.LoadBalancer>("load_balancers/{id}", parameters, body, "load_balancers", Method.PUT);
		}

		[Fact]
		public void CorrectRequestForAddDroplets() {
			var factory = Substitute.For<IConnection>();
			var client = new LoadBalancerClient(factory);

			var body = new LoadBalancerDroplets();
			client.AddDroplets("15", body);

			var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "15");
			factory.Received().ExecuteRaw("load_balancers/{id}/droplets", parameters, body, Method.POST);
		}

		[Fact]
		public void CorrectRequestForRemoveDroplets() {
			var factory = Substitute.For<IConnection>();
			var client = new LoadBalancerClient(factory);

			var body = new LoadBalancerDroplets();
			client.RemoveDroplets("15", body);

			var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "15");
			factory.Received().ExecuteRaw("load_balancers/{id}/droplets", parameters, body,  Method.DELETE);
		}

		[Fact]
		public void CorrectRequestForAddForwardingRules() {
			var factory = Substitute.For<IConnection>();
			var client = new LoadBalancerClient(factory);

			var requestBody = new ForwardingRulesList() {
			    ForwardingRules = new List<ForwardingRule>()
			    {
			        new ForwardingRule()
			    }
			};
			client.AddForwardingRules("15", requestBody);

			var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "15");
			var body = Arg.Is<ForwardingRulesList>(ls => ls.ForwardingRules.SequenceEqual(requestBody.ForwardingRules));
			factory.Received().ExecuteRaw("load_balancers/{id}/forwarding_rules", parameters, body, Method.POST);
		}

		[Fact]
		public void CorrectRequestForRemoveForwardingRules() {
			var factory = Substitute.For<IConnection>();
			var client = new LoadBalancerClient(factory);

			var requestBody = new ForwardingRulesList() {
		        ForwardingRules = new List<ForwardingRule>()
			    {
			        new ForwardingRule()
			    }
			};
			client.RemoveForwardingRules("15", requestBody);

			var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "15");
			var body = Arg.Is<ForwardingRulesList>(ls => ls.ForwardingRules.SequenceEqual(requestBody.ForwardingRules));
			factory.Received().ExecuteRaw("load_balancers/{id}/forwarding_rules", parameters, body, Method.DELETE);
		}
	}
}
