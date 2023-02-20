using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Models.Requests;
using DigitalOcean.API.Models.Responses;
using Image = DigitalOcean.API.Models.Responses.Image;

namespace DigitalOcean.API.Clients {
    public interface IImagesClient {
        /// <summary>
        /// Retrieve all images available ony your account.
        /// </summary>
        Task<IReadOnlyList<Image>> GetAll(ImageType type = ImageType.All);

        /// <summary>
        /// To list all images assigned to a specific tag.
        /// </summary>
        Task<IReadOnlyList<Image>> GetAllByTag(string tag);

        /// <summary>
        /// To retrieve all actions that have been executed on an image.
        /// </summary>
        Task<IReadOnlyList<Action>> GetAllActions(long imageId);

        /// <summary>
        /// To create a new custom image.
        /// The image must be in the raw, qcow2, vhdx, vdi, or vmdk format.
        /// It may be compressed using gzip or bzip2 and must be smaller than 100 GB after being decompressed.
        /// </summary>
        Task<Image> Create(Models.Requests.Image image);

        /// <summary>
        /// Retrieve information about a public or private image on your account.
        /// </summary>
        /// <remarks>
        /// You can only retrieve information about public images when using a slug.
        /// </remarks>
        Task<Image> Get(object imageIdOrSlug);

        /// <summary>
        /// Delete an existing image
        /// </summary>
        Task Delete(long imageId);

        /// <summary>
        /// Update an existing image
        /// </summary>
        Task<Image> Update(long imageId, Models.Requests.UpdateImage updateImage);
    }
}
