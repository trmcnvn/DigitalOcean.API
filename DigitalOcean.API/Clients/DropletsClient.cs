using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Extensions;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using RestSharp;

namespace DigitalOcean.API.Clients {
    public class DropletsClient : IDropletsClient {
        private readonly IConnection _connection;

        public DropletsClient(IConnection connection) {
            _connection = connection;
        }

        #region IDropletsClient Members

        /// <summary>
        /// Retrieve all Droplets in your account.
        /// </summary>
        public Task<IReadOnlyList<Droplet>> GetAll() {
            return _connection.GetPaginated<Droplet>("droplets", null, "droplets");
        }

        /// <summary>
        /// Retrieve all Droplets in your account.
        /// </summary>
        public Task<IReadOnlyList<Droplet>> GetAllByTag(string tagName) {
            var parameters = new List<Parameter> {
                new Parameter("tag_name", tagName, ParameterType.QueryString)
            };

            return _connection.GetPaginated<Droplet>("droplets", parameters, "droplets");
        }

        /// <summary>
        /// To retrieve a list of Droplets that are running on the same physical server.
        /// </summary>
        public Task<IReadOnlyList<Droplet>> GetAllNeighbors(int dropletId) {
            var parameters = new List<Parameter> {
                new Parameter("id", dropletId, ParameterType.UrlSegment)
            };

            return _connection.GetPaginated<Droplet>("droplets/{id}/neighbors", parameters, "droplets");
        }

        /// <summary>
        /// Retrieve all kernels available to a Droplet.
        /// </summary>
        public Task<IReadOnlyList<Kernel>> GetKernels(int dropletId) {
            var parameters = new List<Parameter> {
                new Parameter("id", dropletId, ParameterType.UrlSegment)
            };
            return _connection.GetPaginated<Kernel>("droplets/{id}/kernels", parameters, "kernels");
        }

        /// <summary>
        /// Retrieve all snapshots that have been created for a Droplet.
        /// </summary>
        public Task<IReadOnlyList<Image>> GetSnapshots(int dropletId) {
            var parameters = new List<Parameter> {
                new Parameter("id", dropletId, ParameterType.UrlSegment)
            };
            return _connection.GetPaginated<Image>("droplets/{id}/snapshots", parameters, "snapshots");
        }

        /// <summary>
        /// Retrieve all backups that have been created for a Droplet.
        /// </summary>
        public Task<IReadOnlyList<Image>> GetBackups(int dropletId) {
            var parameters = new List<Parameter> {
                new Parameter("id", dropletId, ParameterType.UrlSegment)
            };
            return _connection.GetPaginated<Image>("droplets/{id}/backups", parameters, "backups");
        }

        /// <summary>
        /// Retrieve all actions that have been executed on a Droplet.
        /// </summary>
        public Task<IReadOnlyList<Action>> GetActions(int dropletId) {
            var parameters = new List<Parameter> {
                new Parameter("id", dropletId, ParameterType.UrlSegment)
            };
            return _connection.GetPaginated<Action>("droplets/{id}/actions", parameters, "actions");
        }

        /// <summary>
        /// Create a new Droplet
        /// </summary>
        public Task<Droplet> Create(Models.Requests.Droplet droplet) {
            return _connection.ExecuteRequest<Droplet>("droplets", null, droplet, "droplet", Method.POST);
        }

        /// <summary>
        /// To create multiple Droplets.
        /// A Droplet will be created for each name you send using the associated information.
        /// Up to ten Droplets may be created at a time.
        /// </summary>
        public Task<IReadOnlyList<Droplet>> Create(Models.Requests.Droplets droplets) {
            return _connection.ExecuteRequest<List<Droplet>>("droplets", null, droplets, "droplets", Method.POST)
                .ToReadOnlyListAsync();
        }

        /// <summary>
        /// Retrieve an existing Droplet
        /// </summary>
        public Task<Droplet> Get(int dropletId) {
            var parameters = new List<Parameter> {
                new Parameter("id", dropletId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRequest<Droplet>("droplets/{id}", parameters, null, "droplet");
        }

        /// <summary>
        /// Delete an existing Droplet
        /// </summary>
        public Task Delete(int dropletId) {
            var parameters = new List<Parameter> {
                new Parameter("id", dropletId, ParameterType.UrlSegment)
            };
            return _connection.ExecuteRaw("droplets/{id}", parameters, null, Method.DELETE);
        }

        /// <summary>
        /// Delete existing droplets by tag
        /// </summary>
        public Task DeleteByTag(string tagName) {
            var parameters = new List<Parameter> {
                new Parameter("tag_name", tagName, ParameterType.QueryString)
            };
            return _connection.ExecuteRaw("droplets", parameters, null, Method.DELETE);
        }

        /// <summary>
        /// To retrieve a list of any Droplets that are running on the same physical hardware.
        /// </summary>
        public Task<IReadOnlyList<Droplet>> ListDropletNeighbors() {
            return _connection.GetPaginated<Droplet>("reports/droplet_neighbors", null, "neighbors");
        }

        #endregion
    }
}
