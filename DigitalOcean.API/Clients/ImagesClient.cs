﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Requests;
using RestSharp;
using Image = DigitalOcean.API.Models.Responses.Image;

namespace DigitalOcean.API.Clients {
    public class ImagesClient : IImagesClient {
        private readonly IConnection _connection;

        public ImagesClient(IConnection connection) {
            _connection = connection;
        }

        #region IImagesClient Members

        /// <summary>
        /// Retrieve all images available on your account.
        /// </summary>
        public Task<IReadOnlyList<Image>> GetAll(ImageType type = ImageType.All) {
            var endpoint = "images";
            switch (type)
            {
                case ImageType.All:
                    break;
                case ImageType.Application:
                    endpoint += "?type=application";
                    break;
                case ImageType.Distribution:
                    endpoint += "?type=distribution";
                    break;
                case ImageType.Private:
                    endpoint += "?private=true";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type));
            }
            return _connection.GetPaginated<Image>(endpoint, null, "images");
        }

        /// <summary>
        /// To create a new custom image.
        /// The image must be in the raw, qcow2, vhdx, vdi, or vmdk format.
        /// It may be compressed using gzip or bzip2 and must be smaller than 100 GB after being decompressed.
        /// </summary>
        public Task<Image> Create(Models.Requests.Image image) {
            return _connection.ExecuteRequest<Image>("images", null, image, "image", Method.POST);
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
            return _connection.ExecuteRaw("images/{id}", parameters, null, Method.DELETE);
        }

        /// <summary>
        /// Update an existing image
        /// </summary>
        public Task<Image> Update(int imageId, Models.Requests.UpdateImage updateImage) {
            var parameters = new List<Parameter> {
                new Parameter { Name = "id", Value = imageId, Type = ParameterType.UrlSegment }
            };
            return _connection.ExecuteRequest<Image>("images/{id}", parameters, updateImage, "image", Method.PUT);
        }

        #endregion
    }
}
