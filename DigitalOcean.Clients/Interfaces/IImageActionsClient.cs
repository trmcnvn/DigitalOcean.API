namespace DigitalOcean.Clients.Interfaces; 

public interface IImageActionsClient {
    /// <summary>
    /// Transfer an Image to another region
    /// </summary>
    Task<Action> Transfer(long imageId, string regionSlug);

    /// <summary>
    /// To convert an image, for example, a backup to a snapshot.
    /// </summary>
    Task<Action> Convert(long imageId);

    /// <summary>
    /// Retrieve an existing Image Action
    /// </summary>
    Task<Action> GetAction(long imageId, long actionId);
}