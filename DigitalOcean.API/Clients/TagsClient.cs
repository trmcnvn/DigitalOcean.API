using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using RestSharp;

namespace DigitalOcean.API.Clients {
    public class TagsClient : ITagsClient {
        private readonly IConnection _connection;

        public TagsClient(IConnection connection) {
            _connection = connection;
        }

        #region ITagsClient Members

        /// <summary>
        /// Retrieve all Tags in your account
        /// </summary>
        public Task<IReadOnlyList<Tag>> GetAll() {
            return _connection.GetPaginated<Tag>("tags", null, "tags");
        }

        /// <summary>
        /// Retrieve an individual Tag by name
        /// </summary>
        public Task<Tag> Get(string tagName) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("name", tagName)
            };
            return _connection.ExecuteRequest<Tag>("tags/{name}", parameters, null, "tag");
        }

        /// <summary>
        /// Create a new Tag
        /// </summary>
        public Task<Tag> Create(string tagName) {
            var data = new Models.Requests.Tag {
                Name = tagName
            };

            return _connection.ExecuteRequest<Tag>("tags", null, data, "tag", Method.Post);
        }

        /// <summary>
        /// Tag existing resources of given resource id / type combination
        /// </summary>
        public Task Tag(string tagName, Models.Requests.TagResources resources) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("name", tagName)
            };

            return _connection.ExecuteRaw("tags/{name}/resources", parameters, resources, Method.Post);
        }

        /// <summary>
        /// Untag existing resources of given resource id / type combination
        /// </summary>
        public Task Untag(string tagName, Models.Requests.TagResources resources) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("name", tagName)
            };

            return _connection.ExecuteRaw("tags/{name}/resources", parameters, resources, Method.Delete);
        }

        /// <summary>
        /// Delete an existing Tag
        /// </summary>
        public Task Delete(string tagName) {
            var parameters = new List<Parameter> {
                new UrlSegmentParameter ("name", tagName)
            };
            return _connection.ExecuteRaw("tags/{name}", parameters, null, Method.Delete);
        }

        #endregion
    }
}
