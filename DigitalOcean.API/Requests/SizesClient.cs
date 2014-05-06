using System.Threading.Tasks;
using DigitalOcean.API.Helpers;
using DigitalOcean.API.Responses;
using RestSharp;

namespace DigitalOcean.API.Requests {
    public interface ISizesClient {
        /// <summary>
        /// This method returns all the available sizes that can be used to create a droplet
        /// </summary>
        Task<Sizes> GetSizes();
    }

    public class SizesClient : Request, ISizesClient {
        public SizesClient(IRestClient restClient) : base(restClient) {}

        #region ISizesClient Members

        public async Task<Sizes> GetSizes() {
            var req = new RestRequest("sizes");
            var ret = await RestClient.ExecuteTask<Sizes>(req);
            return ret.Data;
        }

        #endregion
    }
}