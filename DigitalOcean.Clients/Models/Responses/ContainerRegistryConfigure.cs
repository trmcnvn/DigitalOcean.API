using System;

namespace DigitalOcean.API.Models.Responses; 

public class ContainerRegistryConfigure {
    /// <summary>
    /// Registry information.
    /// </summary>
    public ContainerRegistry Registry { get; set; }

    /// <summary>
    /// Subscription information.
    /// </summary>
    public Subscription Subscription { get; set; }

    /// <summary>
    /// The time at which the subscription was created.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// The time at which the subscription was last updated.
    /// </summary>
    public DateTimeOffset UpdatedAt { get; set; }
}