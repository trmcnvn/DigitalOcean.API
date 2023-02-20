using System.Collections.Generic;

namespace DigitalOcean.API.Models.Responses; 

public class KubernetesNodePool {
    /// <summary>
    /// A unique ID that can be used to identify and reference a specific node pool.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// A human-readable name for the node pool.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The slug identifier for the type of Droplet used as workers in the node pool.
    /// </summary>
    public string Size { get; set; }

    /// <summary>
    /// The number of Droplet instances in the node pool.
    /// </summary>
    public string Count { get; set; }

    /// <summary>
    /// An array containing the tags applied to the node pool.
    /// All node pools are automatically tagged "k8s," "k8s-worker," and "k8s:$K8S_CLUSTER_ID."
    /// </summary>
    public List<string> Tags { get; set; }

    /// <summary>
    /// An object containing a set of Kubernetes labels.
    /// The keys are user-defined.
    /// </summary>
    public Dictionary<string, string> Labels { get; set; }

    /// <summary>
    /// An object specifying the details of a specific worker node in a node pool
    /// </summary>
    public List<KubernetesNode> Nodes { get; set; }

    /// <summary>
    /// A boolean value indicating whether auto-scaling is enabled for this node pool.
    /// This requires DOKS versions at least 1.13.10-do.3, 1.14.6-do.3, or 1.15.3-do.3.
    /// </summary>
    public bool? AutoScale { get; set; }

    /// <summary>
    /// The minimum number of nodes that this node pool can be auto-scaled to.
    /// This will fail validation if the additional nodes will exceed your account droplet limit.
    /// </summary>
    public string MinNodes { get; set; }

    /// <summary>
    /// The maximum number of nodes that this node pool can be auto-scaled to.
    /// This can be 0, but your cluster must contain at least 1 node across all node pools.
    /// </summary>
    public string MaxNodes { get; set; }
}