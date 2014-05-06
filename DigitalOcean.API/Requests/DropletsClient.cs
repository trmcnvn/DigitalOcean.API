using System.Threading.Tasks;
using DigitalOcean.API.Helpers;
using DigitalOcean.API.Responses;
using RestSharp;

namespace DigitalOcean.API.Requests {
    public interface IDropletsClient {
        /// <summary>
        /// This method returns all active droplets that are currently running in your account.
        /// </summary>
        Task<Droplets> GetDroplets();

        /// <summary>
        /// This method allows you to create a new droplet.
        /// </summary>
        /// <param name="name">name of the droplet</param>
        /// <param name="sizeId">id of the size with which you would like the droplet created</param>
        /// <param name="imageId">id of the image you would like the droplet created with</param>
        /// <param name="regionId">id of the region you would like your server in</param>
        /// <param name="sshKeyIds">comma separated list of ssh keys that you would like to be added to the server</param>
        /// <param name="privateNetworking">enabled a private network interface if the region supports private networking</param>
        /// <param name="backupsEnabled">enables backups for your droplet</param>
        Task<NewDroplet> CreateDroplet(string name, int sizeId, int imageId, int regionId, string sshKeyIds = "",
            bool privateNetworking = false, bool backupsEnabled = false);

        /// <summary>
        /// This method allows you to create a new droplet.
        /// </summary>
        /// <param name="name">name of the droplet</param>
        /// <param name="sizeSlug">slug of the size with which you would like the droplet created</param>
        /// <param name="imageSlug">slug of the image you would like the droplet created with</param>
        /// <param name="regionSlug">slug of the region you would like your server in</param>
        /// <param name="sshKeyIds">comma separated list of ssh keys that you would like to be added to the server</param>
        /// <param name="privateNetworking">enabled a private network interface if the region supports private networking</param>
        /// <param name="backupsEnabled">enables backups for your droplet</param>
        Task<NewDroplet> CreateDroplet(string name, string sizeSlug, string imageSlug, string regionSlug,
            string sshKeyIds = "", bool privateNetworking = false, bool backupsEnabled = false);

        /// <summary>
        /// This method returns full information for a specific droplet
        /// </summary>
        /// <param name="id">id of your droplet</param>
        Task<Droplet> GetDroplet(int id);

        /// <summary>
        /// This method allows you to reboot a droplet. This is the preferred method to use if a server is not responding.
        /// </summary>
        /// <param name="id">id of your droplet that you want to reboot</param>
        Task<EventPtr> RebootDroplet(int id);

        /// <summary>
        /// This method allows you to power cycle a droplet. This will turn off the droplet and then turn it back on.
        /// </summary>
        /// <param name="id">id of your droplet that you want to power cycle</param>
        Task<EventPtr> PowerCycleDroplet(int id);

        /// <summary>
        /// This method allows you to shutdown a running droplet. The droplet will remain in your account.
        /// </summary>
        /// <param name="id">id of your droplet that you want to shutdown</param>
        Task<EventPtr> ShutDownDroplet(int id);

        /// <summary>
        /// This method allows you to poweroff a running droplet. The droplet will remain in your account.
        /// </summary>
        /// <param name="id">id of your droplet that you want to power off</param>
        Task<EventPtr> PowerOffDroplet(int id);

        /// <summary>
        /// This method allows you to poweron a powered off droplet.
        /// </summary>
        /// <param name="id">id of your droplet that you want to power on</param>
        Task<EventPtr> PowerOnDroplet(int id);

        /// <summary>
        /// This method will reset the root password for a droplet. Please be aware that this will reboot the droplet to allow
        /// resetting the password.
        /// </summary>
        /// <param name="id">id of the droplet you want to reset the root password for</param>
        Task<EventPtr> ResetRootPassword(int id);

        /// <summary>
        /// This method allows you to resize a specific droplet to a different size
        /// </summary>
        /// <param name="id">id of your droplet you want to resize</param>
        /// <param name="sizeId">id of the size with which you would like the droplet created</param>
        Task<EventPtr> ResizeDroplet(int id, int sizeId);

        /// <summary>
        /// This method allows you to resize a specific droplet to a different size
        /// </summary>
        /// <param name="id">id of your droplet you want to resize</param>
        /// <param name="sizeSlug">slug of the size with which you would like the droplet created</param>
        Task<EventPtr> ResizeDroplet(int id, string sizeSlug);

        /// <summary>
        /// This method allows you to take a snapshot of the droplet once it has been powered off, which can later be restored or
        /// used to create a new droplet from the same image
        /// </summary>
        /// <param name="id">id of your droplet you want to create a snapshot of</param>
        /// <param name="name">name of the snapshot, the snapshot name will default to date/time</param>
        Task<EventPtr> CreateSnapshot(int id, string name = "");

        /// <summary>
        /// This method allows you to restore a droplet with a previous image or snapshot
        /// </summary>
        /// <param name="id">id of your droplet that you want to restore</param>
        /// <param name="imageId">id of the image you would like to use to restore your droplet with</param>
        Task<EventPtr> RestoreDroplet(int id, int imageId);

        /// <summary>
        /// This method allows you to reinstall a droplet with a default image
        /// </summary>
        /// <param name="id">id of your droplet that you want to rebuild</param>
        /// <param name="imageId">id of the image you would like to use to rebuild your droplet with</param>
        Task<EventPtr> RebuildDroplet(int id, int imageId);

        /// <summary>
        /// This method renames the droplet to the specified name
        /// </summary>
        /// <param name="id">id of your droplet that you want to rename</param>
        /// <param name="name">new name of your droplet</param>
        Task<EventPtr> RenameDroplet(int id, string name);

        /// <summary>
        /// This method destroys one of your droplets - this is irreversible.
        /// </summary>
        /// <param name="id">id of your droplet that you want to destroy</param>
        /// <param name="scrubData">
        /// this will strictly write 0s to your prior partition to ensure that all data is completely
        /// erased
        /// </param>
        Task<EventPtr> DestroyDroplet(int id, bool scrubData = false);
    }

    public class DropletsClient : Request, IDropletsClient {
        public DropletsClient(IRestClient restClient) : base(restClient) {}

        #region IDropletsClient Members

        public async Task<Droplets> GetDroplets() {
            var req = new RestRequest("droplets");
            var ret = await RestClient.ExecuteTask<Droplets>(req);
            return ret.Data;
        }

        public async Task<NewDroplet> CreateDroplet(string name, int sizeId, int imageId, int regionId,
            string sshKeyIds = "",
            bool privateNetworking = false, bool backupsEnabled = false) {
            var req = new RestRequest("droplets/new");
            req.AddParameter("name", name);
            req.AddParameter("size_id", sizeId);
            req.AddParameter("image_id", imageId);
            req.AddParameter("region_id", regionId);
            req.AddParameter("ssh_key_ids", sshKeyIds);
            req.AddParameter("private_networking", privateNetworking);
            req.AddParameter("backups_enabled", backupsEnabled);

            var ret = await RestClient.ExecuteTask<NewDroplet>(req);
            return ret.Data;
        }

        public async Task<NewDroplet> CreateDroplet(string name, string sizeSlug, string imageSlug, string regionSlug,
            string sshKeyIds = "",
            bool privateNetworking = false, bool backupsEnabled = false) {
            var req = new RestRequest("droplets/new");
            req.AddParameter("name", name);
            req.AddParameter("size_slug", sizeSlug);
            req.AddParameter("image_slug", imageSlug);
            req.AddParameter("region_slug", regionSlug);
            req.AddParameter("ssh_key_ids", sshKeyIds);
            req.AddParameter("private_networking", privateNetworking);
            req.AddParameter("backups_enabled", backupsEnabled);

            var ret = await RestClient.ExecuteTask<NewDroplet>(req);
            return ret.Data;
        }

        public async Task<Droplet> GetDroplet(int id) {
            var req = new RestRequest("droplets/{id}");
            req.AddParameter("id", id, ParameterType.UrlSegment);
            var ret = await RestClient.ExecuteTask<Droplet>(req);
            return ret.Data;
        }

        public async Task<EventPtr> RebootDroplet(int id) {
            var req = new RestRequest("droplets/{id}/reboot");
            req.AddParameter("id", id, ParameterType.UrlSegment);
            var ret = await RestClient.ExecuteTask<EventPtr>(req);
            return ret.Data;
        }

        public async Task<EventPtr> PowerCycleDroplet(int id) {
            var req = new RestRequest("droplets/{id}/power_cycle");
            req.AddParameter("id", id, ParameterType.UrlSegment);
            var ret = await RestClient.ExecuteTask<EventPtr>(req);
            return ret.Data;
        }

        public async Task<EventPtr> ShutDownDroplet(int id) {
            var req = new RestRequest("droplets/{id}/shutdown");
            req.AddParameter("id", id, ParameterType.UrlSegment);
            var ret = await RestClient.ExecuteTask<EventPtr>(req);
            return ret.Data;
        }

        public async Task<EventPtr> PowerOffDroplet(int id) {
            var req = new RestRequest("droplets/{id}/power_off");
            req.AddParameter("id", id, ParameterType.UrlSegment);
            var ret = await RestClient.ExecuteTask<EventPtr>(req);
            return ret.Data;
        }

        public async Task<EventPtr> PowerOnDroplet(int id) {
            var req = new RestRequest("droplets/{id}/power_on");
            req.AddParameter("id", id, ParameterType.UrlSegment);
            var ret = await RestClient.ExecuteTask<EventPtr>(req);
            return ret.Data;
        }

        public async Task<EventPtr> ResetRootPassword(int id) {
            var req = new RestRequest("droplets/{id}/password_reset");
            req.AddParameter("id", id, ParameterType.UrlSegment);
            var ret = await RestClient.ExecuteTask<EventPtr>(req);
            return ret.Data;
        }

        public async Task<EventPtr> ResizeDroplet(int id, int sizeId) {
            var req = new RestRequest("droplets/{id}/resize");
            req.AddParameter("id", id, ParameterType.UrlSegment);
            req.AddParameter("size_id", sizeId);
            var ret = await RestClient.ExecuteTask<EventPtr>(req);
            return ret.Data;
        }

        public async Task<EventPtr> ResizeDroplet(int id, string sizeSlug) {
            var req = new RestRequest("droplets/{id}/resize");
            req.AddParameter("id", id, ParameterType.UrlSegment);
            req.AddParameter("size_slug", sizeSlug);
            var ret = await RestClient.ExecuteTask<EventPtr>(req);
            return ret.Data;
        }

        public async Task<EventPtr> CreateSnapshot(int id, string name = "") {
            var req = new RestRequest("droplets/{id}/snapshot");
            req.AddParameter("id", id, ParameterType.UrlSegment);
            req.AddParameter("name", name);
            var ret = await RestClient.ExecuteTask<EventPtr>(req);
            return ret.Data;
        }

        public async Task<EventPtr> RestoreDroplet(int id, int imageId) {
            var req = new RestRequest("droplets/{id}/restore");
            req.AddParameter("id", id, ParameterType.UrlSegment);
            req.AddParameter("image_id", imageId);
            var ret = await RestClient.ExecuteTask<EventPtr>(req);
            return ret.Data;
        }

        public async Task<EventPtr> RebuildDroplet(int id, int imageId) {
            var req = new RestRequest("droplets/{id}/rebuild");
            req.AddParameter("id", id, ParameterType.UrlSegment);
            req.AddParameter("image_id", imageId);
            var ret = await RestClient.ExecuteTask<EventPtr>(req);
            return ret.Data;
        }

        public async Task<EventPtr> RenameDroplet(int id, string name) {
            var req = new RestRequest("droplets/{id}/rename");
            req.AddParameter("id", id, ParameterType.UrlSegment);
            req.AddParameter("name", name);
            var ret = await RestClient.ExecuteTask<EventPtr>(req);
            return ret.Data;
        }

        public async Task<EventPtr> DestroyDroplet(int id, bool scrubData = false) {
            var req = new RestRequest("droplets/{id}/destroy");
            req.AddParameter("id", id, ParameterType.UrlSegment);
            req.AddParameter("scrub_data", scrubData);
            var ret = await RestClient.ExecuteTask<EventPtr>(req);
            return ret.Data;
        }

        #endregion
    }
}