namespace DigitalOcean.Clients.Models.Responses; 

public class ProjectResource {
    /// <summary>
    /// The uniform resource name of the resource.
    /// </summary>
    public string Urn { get; set; }

    /// <summary>
    /// A time value given in ISO8601 combined date and time format that represents when the project was created.
    /// </summary>
    public DateTime AssignedAt { get; set; }

    /// <summary>
    /// The links object contains the self object, which contains the resource relationship.
    /// </summary>
    public SelfLink Links { get; set; }

    /// <summary>
    /// The status of assigning and fetching the resources.
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// The links object contains the self object, which contains the resource relationship.
    /// </summary>
    public class SelfLink {
        public string Self { get; set; }
    }

    /// <summary>
    /// When assigning and retrieving resources in projects, a status attribute is returned that indicates if a resource was successfully
    /// retrieved or assigned. The status codes can be one of the following:
    /// </summary>
    public static class ProjectResourceStatusCodes {
        public const string OK = "ok";
        public const string NOT_FOUND = "not_found";
        public const string ASSIGNED = "assigned";
        public const string ALREADY_ASSIGNED = "already_assigned";
        public const string SERVICE_DOWN = "service_down";
    }
}