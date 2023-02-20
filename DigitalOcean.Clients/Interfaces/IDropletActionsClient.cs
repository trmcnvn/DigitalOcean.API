using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface IDropletActionsClient {
        /// <summary>
        /// Reboot a droplet
        /// </summary>
        Task<Action> Reboot(long dropletId);

        /// <summary>
        /// Power cycle a droplet
        /// </summary>
        Task<Action> PowerCycle(long dropletId);

        /// <summary>
        /// Shutdown a droplet
        /// </summary>
        Task<Action> Shutdown(long dropletId);

        /// <summary>
        /// Turn off a droplet
        /// </summary>
        Task<Action> PowerOff(long dropletId);

        /// <summary>
        /// Turn on a droplet
        /// </summary>
        Task<Action> PowerOn(long dropletId);

        /// <summary>
        /// Reset the root password of the droplet
        /// </summary>
        Task<Action> ResetPassword(long dropletId);

        /// <summary>
        /// Resize a droplet
        /// </summary>
        Task<Action> Resize(long dropletId, string sizeSlug, bool resizeDisk = false);

        /// <summary>
        /// Restore a droplet using an image
        /// A Droplet restoration will rebuild an image using a backup image. The image ID that is passed in must be a backup of
        /// the current Droplet instance. The operation will leave any embedded SSH keys intact.
        /// </summary>
        Task<Action> Restore(long dropletId, object imageIdOrSlug);

        /// <summary>
        /// Rebuild a droplet
        /// </summary>
        Task<Action> Rebuild(long dropletId, object imageIdOrSlug);

        /// <summary>
        /// Rename a droplets hostname
        /// </summary>
        Task<Action> Rename(long dropletId, string name);

        /// <summary>
        /// Chane the kernel of a droplet
        /// </summary>
        Task<Action> ChangeKernel(long dropletId, long kernelId);

        /// <summary>
        /// Enable IPv6 networking on a droplet
        /// </summary>
        Task<Action> EnableIpv6(long dropletId);

        /// <summary>
        /// Enable backups on a droplet
        /// </summary>
        Task<Action> EnableBackups(long dropletId);

        /// <summary>
        /// Disable backups on a droplet
        /// </summary>
        Task<Action> DisableBackups(long dropletId);

        /// <summary>
        /// Enable private networking on a droplet
        /// When VPC is enabled on your account, this will add the Droplet to your account's default VPC for the region.
        /// </summary>
        Task<Action> EnablePrivateNetworking(long dropletId);

        /// <summary>
        /// Create a snapshot of a droplet
        /// </summary>
        Task<Action> Snapshot(long dropletId, string name);

        /// <summary>
        /// Retrieve an action for a droplet
        /// </summary>
        Task<Action> GetDropletAction(long dropletId, long actionId);

        /// <summary>
        /// Some actions can be performed in bulk on tagged Droplets.
        /// The list of supported action types are:
        /// * power_cycle
        /// * power_on
        /// * power_off
        /// * shutdown
        /// * enable_private_networking
        /// * enable_ipv6
        /// * enable_backups
        /// * disable_backups
        /// * snapshot
        /// </summary>
        Task<IReadOnlyList<Action>> ActionOnTag(string tag, string actionType);
    }
}
