using System.Threading.Tasks;
using DigitalOcean.API.Helpers;
using DigitalOcean.API.Responses;
using RestSharp;

namespace DigitalOcean.API.Requests {
    public interface ISshKeysClient {
        /// <summary>
        /// This method lists all the available public SSH keys in your account that can be added to a droplet
        /// </summary>
        Task<SshKeys> GetKeys();

        /// <summary>
        /// This method allows you to add a new public SSH key to your account
        /// </summary>
        /// <param name="name">name you want to give this SSH key</param>
        /// <param name="pubKey">he actual public SSH key</param>
        Task<SshKey> AddKey(string name, string pubKey);

        /// <summary>
        /// This method shows a specific public SSH key in your account that can be added to a droplet
        /// </summary>
        /// <param name="keyId">id of the key to return</param>
        Task<SshKey> GetKey(int keyId);

        /// <summary>
        /// This method allows you to modify an existing public SSH key in your account
        /// </summary>
        /// <param name="keyId">id of the key you want to edit</param>
        /// <param name="name">new name of the SSH key</param>
        /// <param name="pubKey">new content of the public SSH key</param>
        Task<SshKey> EditKey(int keyId, string name = "", string pubKey = "");

        /// <summary>
        /// This method will delete the SSH key from your account
        /// </summary>
        /// <param name="keyId">id of the key you wish to delete</param>
        Task<Status> DestroyKey(int keyId);
    }

    public class SshKeysClient : Request, ISshKeysClient {
        public SshKeysClient(IRestClient restClient) : base(restClient) {}

        #region ISshKeysClient Members

        public async Task<SshKeys> GetKeys() {
            var req = new RestRequest("ssh_keys");
            var ret = await RestClient.ExecuteTask<SshKeys>(req);
            return ret.Data;
        }

        public async Task<SshKey> AddKey(string name, string pubKey) {
            var req = new RestRequest("ssh_keys/new");
            req.AddParameter("name", name);
            req.AddParameter("ssh_pub_key", pubKey);
            var ret = await RestClient.ExecuteTask<SshKey>(req);
            return ret.Data;
        }

        public async Task<SshKey> GetKey(int keyId) {
            var req = new RestRequest("ssh_keys/{id}");
            req.AddParameter("id", keyId, ParameterType.UrlSegment);
            var ret = await RestClient.ExecuteTask<SshKey>(req);
            return ret.Data;
        }

        public async Task<SshKey> EditKey(int keyId, string name = "", string pubKey = "") {
            var req = new RestRequest("ssh_keys/{id}/edit");
            req.AddParameter("id", keyId, ParameterType.UrlSegment);
            req.AddParameter("name", name);
            req.AddParameter("ssh_pub_key", pubKey);
            var ret = await RestClient.ExecuteTask<SshKey>(req);
            return ret.Data;
        }

        public async Task<Status> DestroyKey(int keyId) {
            var req = new RestRequest("ssh_keys/{id}/destroy");
            req.AddParameter("id", keyId, ParameterType.UrlSegment);
            var ret = await RestClient.ExecuteTask<Status>(req);
            return ret.Data;
        }

        #endregion
    }
}