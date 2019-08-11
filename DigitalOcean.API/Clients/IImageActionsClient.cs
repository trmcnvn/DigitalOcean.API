using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;

namespace DigitalOcean.API.Clients {
    public interface IImageActionsClient {
        /// <summary>
        /// Transfer an Image to another region
        /// </summary>
        Task<Action> Transfer(int imageId, string regionSlug);

        /// <summary>
        /// To convert an image, for example, a backup to a snapshot.
        /// </summary>
        Task<Action> Convert(int imageId);

        /// <summary>
        /// Retrieve an existing Image Action
        /// </summary>
        Task<Action> GetAction(int imageId, int actionId);
    }
}
