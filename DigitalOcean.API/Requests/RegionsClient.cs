using System.Threading.Tasks;
using DigitalOcean.API.Helpers;
using DigitalOcean.API.Responses;
using RestSharp;

namespace DigitalOcean.API.Requests {
    public interface IRegionsClient {
        /// <summary>
        /// This method will return all the available regions within the DigitalOcean cloud
        /// </summary>
        Task<Regions> GetRegions();
    }

    public class RegionsClient : Request, IRegionsClient {
        public RegionsClient(IRestClient restClient) : base(restClient) {}

        #region IRegionsClient Members

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<Regions> GetRegions() {
            var req = new RestRequest("regions");
            var ret = await RestClient.ExecuteTask<Regions>(req);
            return ret.Data;
        }

        #endregion
    }
}