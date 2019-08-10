using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface IVolumeActionsClient {
        /// <summary>
        /// Attach a Block Storage volume to a Droplet
        /// </summary>
        Task<Action> Attach(string volumeId, int dropletId, string volumeRegion = null);

        /// <summary>
        /// Attach a Block Storage volume to a Droplet by name
        /// </summary>
        Task<Action> AttachByName(string volumeName, int dropletId, string volumeRegion = null);

        /// <summary>
        /// Detach a Block Storage volume to a Droplet
        /// </summary>
        Task<Action> Detach(string volumeId, int dropletId, string volumeRegion = null);

        /// <summary>
        /// Detach a Block Storage volume to a Droplet by name
        /// </summary>
        Task<Action> DetachByName(string volumeName, int dropletId, string volumeRegion = null);

        /// <summary>
        /// Resize a Block Storage volume
        /// </summary>
        Task<Action> Resize(string volumeId, int sizeGigabytes, string volumeRegion = null);

        /// <summary>
        /// Retreive all actions that have been executed on a volume
        /// </summary>
        Task<IReadOnlyList<Action>> GetActions(string volumeId);

        /// <summary>
        /// Retreive the status of a volume action
        /// </summary>
        Task<Action> GetAction(string volumeId, int actionId);
    }
}
