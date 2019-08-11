using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using RestSharp;

namespace DigitalOcean.API.Clients {
    public class FloatingIpsClient : IFloatingIpsClient {
        private readonly IConnection _connection;

        public FloatingIpsClient(IConnection connection) {
            _connection = connection;
        }

        /// <summary>
        /// A Floating IP must be either assigned to a Droplet or reserved to a region
        /// </summary>
        public Task<FloatingIp> Create(Models.Requests.FloatingIp floatingIp) {
            return _connection.ExecuteRequest<FloatingIp>("floating_ips", null, floatingIp, "floating_ip", Method.POST);
        }

        /// <summary>
        /// Delete a Floating IP
        /// </summary>
        public Task Delete(string ipAddress) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "ip", Value = ipAddress, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRaw("floating_ips/{ip}", parameters, null, Method.DELETE);
        }

        /// <summary>
        /// Retreive a individual Floating IP
        /// </summary>
        public Task<FloatingIp> Get(string ipAddress) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "ip", Value = ipAddress, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRequest<FloatingIp>("floating_ips/{ip}", parameters, null, "floating_ip");
        }

        /// <summary>
        /// Retreive all Floating IPs available on your account
        /// </summary>
        public Task<IReadOnlyList<FloatingIp>> GetAll() {
            return _connection.GetPaginated<FloatingIp>("floating_ips", null, "floating_ips");
        }
    }
}
