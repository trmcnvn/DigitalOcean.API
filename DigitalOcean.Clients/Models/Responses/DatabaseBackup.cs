namespace DigitalOcean.Clients.Models.Responses; 

public class DatabaseBackup {
    /// <summary>
    /// A time value given in ISO8601 combined date and time format at which the backup was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// The size of the database backup in GBs.
    /// </summary>
    public double SizeGigabytes { get; set; }
}