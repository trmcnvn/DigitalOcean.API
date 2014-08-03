using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface IDropletActionsClient {
        /// <summary>
        /// Reboot a droplet
        /// </summary>
        Task<Action> Reboot(int dropletId);

        /// <summary>
        /// Power cycle a droplet
        /// </summary>
        Task<Action> PowerCycle(int dropletId);

        /// <summary>
        /// Shutdown a droplet
        /// </summary>
        Task<Action> Shutdown(int dropletId);

        /// <summary>
        /// Turn off a droplet
        /// </summary>
        Task<Action> PowerOff(int dropletId);

        /// <summary>
        /// Turn on a droplet
        /// </summary>
        Task<Action> PowerOn(int dropletId);

        /// <summary>
        /// Reset the root password of the droplet
        /// </summary>
        Task<Action> ResetPassword(int dropletId);

        /// <summary>
        /// Resize a droplet
        /// </summary>
        Task<Action> Resize(int dropletId, string sizeSlug);

        /// <summary>
        /// Restore a droplet using an image
        /// A Droplet restoration will rebuild an image using a backup image. The image ID that is passed in must be a backup of
        /// the current Droplet instance. The operation will leave any embedded SSH keys intact.
        /// </summary>
        Task<Action> Restore(int dropletId, int imageId);

        /// <summary>
        /// Rebuild a droplet
        /// </summary>
        Task<Action> Rebuild(int dropletId, object imageIdOrSlug);

        /// <summary>
        /// Rename a droplets hostname
        /// </summary>
        Task<Action> Rename(int dropletId, string name);

        /// <summary>
        /// Chane the kernel of a droplet
        /// </summary>
        Task<Action> ChangeKernel(int dropletId, int kernelId);

        /// <summary>
        /// Enable IPv6 networking on a droplet
        /// </summary>
        Task<Action> EnableIpv6(int dropletId);

        /// <summary>
        /// Disable backups on a droplet
        /// </summary>
        Task<Action> DisableBackups(int dropletId);

        /// <summary>
        /// Enable private networking on a droplet
        /// </summary>
        Task<Action> EnablePrivateNetworking(int dropletId);

        /// <summary>
        /// Create a snapshot of a droplet
        /// </summary>
        Task<Action> Snapshot(int dropletId, string name);

        /// <summary>
        /// Retrieve an action for a droplet
        /// </summary>
        Task<Action> GetDropletAction(int dropletId, int actionId);
    }
}