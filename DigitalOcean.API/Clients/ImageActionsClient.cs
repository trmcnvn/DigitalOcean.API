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
        public Task<Action> Transfer(long imageId, string regionSlug) {
            var parameters = new List<Parameter> {
                new Parameter("imageId", imageId.ToString(), ParameterType.UrlSegment)
            };

            var body = new Models.Requests.ImageAction {
                Type = "transfer",
                Region = regionSlug
            };

            return _connection.ExecuteRequest<Action>("images/{imageId}/actions", parameters, body, "action",
                Method.POST);
        }

        /// <summary>
        /// To convert an image, for example, a backup to a snapshot.
        /// </summary>
        public Task<Action> Convert(long imageId) {
            var parameters = new List<Parameter> {
                new Parameter("imageId", imageId.ToString(), ParameterType.UrlSegment)
            };

            var body = new Models.Requests.ImageAction {
                Type = "convert"
            };

            return _connection.ExecuteRequest<Action>("images/{imageId}/actions", parameters, body, "action",
                Method.POST);
        }

        /// <summary>
        /// Retrieve an existing Image Action
        /// </summary>
        public Task<Action> GetAction(long imageId, long actionId) {
            var parameters = new List<Parameter> {
                new Parameter("imageId", imageId.ToString(), ParameterType.UrlSegment),
                new Parameter("actionId", actionId.ToString(), ParameterType.UrlSegment)
            };
            return _connection.ExecuteRequest<Action>("images/{imageId}/actions/{actionId}", parameters, null, "action");
        }

        #endregion
    }
}
