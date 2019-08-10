﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using RestSharp;

namespace DigitalOcean.API.Clients {
	public sealed class LoadBalancerClient : ILoadBalancerClient {
		private readonly IConnection _connection;

		public LoadBalancerClient(IConnection connection) {
			_connection = connection;
		}

		public Task<LoadBalancer> Get(string loadBalancerId){
			var parameters = new List<Parameter> {
				new Parameter { Name = "id", Value = loadBalancerId, Type = ParameterType.UrlSegment }
			};
			return _connection.ExecuteRequest<LoadBalancer>("load_balancers/{id}", parameters, null, "load_balancers");
		}

		public Task<IReadOnlyList<LoadBalancer>> GetAll(){
			return _connection.GetPaginated<LoadBalancer>("load_balancers", null, "load_balancers");
		}

		public Task<LoadBalancer> Create(Models.Requests.LoadBalancer loadBalancer){
			return _connection.ExecuteRequest<LoadBalancer>("load_balancers", null, loadBalancer, "load_balancers", Method.POST);
		}

		public Task Delete(string loadBalancerId){
			var parameters = new List<Parameter> {
				new Parameter { Name = "id", Value = loadBalancerId, Type = ParameterType.UrlSegment }
			};
			return _connection.ExecuteRaw("load_balancers/{id}", parameters, null, Method.DELETE);
		}

		public Task Update(string loadBalancerId, Models.Requests.LoadBalancer loadBalancer){
			var parameters = new List<Parameter> {
				new Parameter { Name = "id", Value = loadBalancerId, Type = ParameterType.UrlSegment }
			};
			return _connection.ExecuteRequest<LoadBalancer>("load_balancers/{id}", parameters, loadBalancer, "load_balancers", Method.PUT);
		}

		public Task AddDroplets(string loadBalancerId, Models.Requests.LoadBalancerDroplets dropletIds) {
			var parameters = new List<Parameter> {
				new Parameter { Name = "id", Value = loadBalancerId, Type = ParameterType.UrlSegment }
			};

			return _connection.ExecuteRaw("load_balancers/{id}/droplets", parameters, dropletIds, Method.POST);
		}

		public Task RemoveDroplets(string loadBalancerId, Models.Requests.LoadBalancerDroplets dropletIds) {
			var parameters = new List<Parameter> {
				new Parameter { Name = "id", Value = loadBalancerId, Type = ParameterType.UrlSegment }
			};

			return _connection.ExecuteRaw("load_balancers/{id}/droplets", parameters, dropletIds, Method.DELETE);
		}

		public Task AddForwardingRules(string loadBalancerId, Models.Requests.ForwardingRulesList forwardingRules){
			var parameters = new List<Parameter> {
				new Parameter { Name = "id", Value = loadBalancerId, Type = ParameterType.UrlSegment }
			};

			return _connection.ExecuteRaw("load_balancers/{id}/forwarding_rules", parameters, forwardingRules, Method.POST);
		}

		public Task RemoveForwardingRules(string loadBalancerId, Models.Requests.ForwardingRulesList forwardingRules){
			var parameters = new List<Parameter> {
				new Parameter { Name = "id", Value = loadBalancerId, Type = ParameterType.UrlSegment }
			};

			return _connection.ExecuteRaw("load_balancers/{id}/forwarding_rules", parameters, forwardingRules, Method.DELETE);
		}
	}
}
