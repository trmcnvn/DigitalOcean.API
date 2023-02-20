namespace DigitalOcean.Clients.Models.Responses; 

public class Kernel {
    /// <summary>
    /// A unique number used to identify and reference a specific kernel.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// The display name of the kernel. This is shown in the web UI and is generally a descriptive title for the kernel in
    /// question.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// A standard kernel version string representing the version, patch, and release information.
    /// </summary>
    public string Version { get; set; }
}