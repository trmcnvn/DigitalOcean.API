using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using RestSharp;

namespace DigitalOcean.API.Clients {
    public class ImageActionsClient : IImageActionsClient {
        private readonly IConnection _connection;

        public ImageActionsClient(IConnection connection) {
            _connection = connection;
        }

        #region IImageActionsClient Members

        /// <summary>
        /// Transfer an Image to another region
        /// </summary>
        public Task<Action> Transfer(int imageId, string regionSlug) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "imageId", Value = imageId, Type = ParameterType.UrlSegment }
            };

            var body = new Models.Requests.ImageAction {
                Type = "transfer",
                RegionSlug = regionSlug
            };

            return _connection.ExecuteRequest<Action>("images/{imageId}/actions", parameters, body, "action",
                Method.POST);
        }

        /// <summary>
        /// Retrieve an existing Image Action
        /// </summary>
        public Task<Action> GetAction(int imageId, int actionId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "imageId", Value = imageId, Type = ParameterType.UrlSegment },
                new Parameter { Name = "actionId", Value = actionId, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRequest<Action>("images/{imageId}/actions/{actionId}", parameters, null, "action");
        }

        #endregion
    }
}
