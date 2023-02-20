namespace DigitalOcean.Clients.Models.Responses; 

public class MaintenanceWindow {
    /// <summary>
    /// The day of the week on which to apply maintenance updates (e.g. "tuesday").
    /// </summary>
    public string Day { get; set; }

    /// <summary>
    /// The hour in UTC at which maintenance updates will be applied in 24 hour format (e.g. "16:00:00").
    /// </summary>
    public string Hour { get; set; }

    /// <summary>
    /// A boolean value indicating whether any maintenance is scheduled to be performed in the next window.
    /// </summary>
    public bool Pending { get; set; }

    /// <summary>
    /// A list of strings, each containing information about a pending maintenance update.
    /// </summary>
    public List<string> Description { get; set; }
}