using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using RestSharp;

namespace DigitalOcean.API.Clients {
    public class ImagesClient : IImagesClient {
        private readonly IConnection _connection;

        public ImagesClient(IConnection connection) {
            _connection = connection;
        }

        #region IImagesClient Members

        /// <summary>
        /// Retrieve all images available ony your account.
        /// </summary>
        public Task<IReadOnlyList<Image>> GetAll() {
            return _connection.GetPaginated<Image>("images", null, "images");
        }

        /// <summary>
        /// Retrieve information about a public or private image on your account.
        /// </summary>
        /// <remarks>
        /// You can only retrieve information about public images when using a slug.
        /// </remarks>
        public Task<Image> Get(object imageIdOrSlug) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "id", Value = imageIdOrSlug, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRequest<Image>("images/{id}", parameters, null, "image");
        }

        /// <summary>
        /// Delete an existing image
        /// </summary>
        public Task Delete(int imageId) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "id", Value = imageId, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRaw("images/{id}", parameters, Method.DELETE);
        }

        /// <summary>
        /// Update an existing image
        /// </summary>
        public Task<Image> Update(int imageId, Models.Requests.Image image) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "id", Value = imageId, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRequest<Image>("images/{id}", parameters, image, "image", Method.PUT);
        }

        #endregion
    }
}