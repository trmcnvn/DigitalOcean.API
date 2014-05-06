using System.Threading.Tasks;
using DigitalOcean.API.Helpers;
using DigitalOcean.API.Responses;
using RestSharp;

namespace DigitalOcean.API.Requests {
    public interface IImagesClient {
        /// <summary>
        /// This method returns all the available images that can be accessed by your client ID
        /// </summary>
        /// <param name="filter">either "my_images" or "global"</param>
        Task<Images> GetImages(string filter = "");

        /// <summary>
        /// This method displays the attributes of an image
        /// </summary>
        /// <param name="imageId">id of the image to return</param>
        Task<Image> GetImage(int imageId);

        /// <summary>
        /// This method displays the attributes of an image
        /// </summary>
        /// <param name="imageSlug">slug of the image to return</param>
        /// <returns></returns>
        Task<Image> GetImage(string imageSlug);

        /// <summary>
        /// This method allows you to destroy an image.
        /// </summary>
        /// <param name="imageId">id of the image to destroy</param>
        Task<Status> DestroyImage(int imageId);

        /// <summary>
        /// This method allows you to destroy an image.
        /// </summary>
        /// <param name="imageSlug">slug of the image to destroy</param>
        Task<Status> DestroyImage(string imageSlug);

        /// <summary>
        /// This method allows you to transfer an image to a specified region
        /// </summary>
        /// <param name="imageId">id of the image to transfer</param>
        /// <param name="regionId">id of the region to transfer to</param>
        Task<EventPtr> TransferImage(int imageId, int regionId);

        /// <summary>
        /// This method allows you to transfer an image to a specified region
        /// </summary>
        /// <param name="imageSlug">slug of the image to transfer</param>
        /// <param name="regionId">id of the region to transfer to</param>
        Task<EventPtr> TransferImage(string imageSlug, int regionId);
    }

    public class ImagesClient : Request, IImagesClient {
        public ImagesClient(IRestClient restClient) : base(restClient) {}

        #region IImagesClient Members

        public async Task<Images> GetImages(string filter = "") {
            var req = new RestRequest("images");
            var ret = await RestClient.ExecuteTask<Images>(req);
            return ret.Data;
        }

        public async Task<Image> GetImage(int imageId) {
            var req = new RestRequest("images/{id}");
            req.AddParameter("id", imageId, ParameterType.UrlSegment);
            var ret = await RestClient.ExecuteTask<Image>(req);
            return ret.Data;
        }

        public async Task<Image> GetImage(string imageSlug) {
            var req = new RestRequest("images/{slug}");
            req.AddParameter("slug", imageSlug, ParameterType.UrlSegment);
            var ret = await RestClient.ExecuteTask<Image>(req);
            return ret.Data;
        }

        public async Task<Status> DestroyImage(int imageId) {
            var req = new RestRequest("images/{id}/destroy");
            req.AddParameter("id", imageId, ParameterType.UrlSegment);
            var ret = await RestClient.ExecuteTask<Status>(req);
            return ret.Data;
        }

        public async Task<Status> DestroyImage(string imageSlug) {
            var req = new RestRequest("images/{slug}/destroy");
            req.AddParameter("slug", imageSlug, ParameterType.UrlSegment);
            var ret = await RestClient.ExecuteTask<Status>(req);
            return ret.Data;
        }

        public async Task<EventPtr> TransferImage(int imageId, int regionId) {
            var req = new RestRequest("images/{id}/transfer");
            req.AddParameter("id", imageId, ParameterType.UrlSegment);
            var ret = await RestClient.ExecuteTask<EventPtr>(req);
            return ret.Data;
        }

        public async Task<EventPtr> TransferImage(string imageSlug, int regionId) {
            var req = new RestRequest("images/{slug}/transfer");
            req.AddParameter("slug", imageSlug, ParameterType.UrlSegment);
            var ret = await RestClient.ExecuteTask<EventPtr>(req);
            return ret.Data;
        }

        #endregion
    }
}