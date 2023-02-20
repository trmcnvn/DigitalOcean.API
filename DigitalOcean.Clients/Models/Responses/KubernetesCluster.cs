using System;
using System.Collections.Generic;

namespace DigitalOcean.API.Models.Responses; 

public class KubernetesCluster {
    /// <summary>
    /// A unique ID that can be used to identify and reference a Kubernetes cluster.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// A human-readable name for a Kubernetes cluster.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The base URL of the API server on the Kubernetes master node.
    /// </summary>
    public string Endpoint { get; set; }

    /// <summary>
    /// The slug identifier for the region where the Kubernetes cluster is located.
    /// </summary>
    public string Region { get; set; }

    /// <summary>
    /// The slug identifier for the version of Kubernetes used for the cluster.
    /// </summary>
    public string Version { get; set; }

    /// <summary>
    /// A boolean value indicating whether the cluster will be automatically upgraded to new patch releases during its maintenance window.
    /// </summary>
    public string AutoUpgrade { get; set; }

    /// <summary>
    /// The public IPv4 address of the Kubernetes master node.
    /// </summary>
    public string Ipv4 { get; set; }

    /// <summary>
    /// The range of IP addresses in the overlay network of the Kubernetes cluster in CIDR notation.
    /// </summary>
    public string ClusterSubset { get; set; }

    /// <summary>
    /// The range of assignable IP addresses for services running in the Kubernetes cluster in CIDR notation.
    /// </summary>
    public string ServiceSubset { get; set; }

    /// <summary>
    /// A flat array of tag names as strings to be applied to the Kubernetes cluster.
    /// All clusters will be automatically tagged "k8s" and "k8s:$K8S_CLUSTER_ID" in addition to any tags provided by the user.
    /// </summary>
    public List<string> Tags { get; set; }

    /// <summary>
    /// An object specifying the maintenance window policy for the Kubernetes cluster.
    /// </summary>
    public MaintenancePolicy MaintenancePolicy { get; set; }

    /// <summary>
    /// An object specifying the details of the worker nodes available to the Kubernetes cluster.
    /// </summary>
    public List<KubernetesNodePool> NodePools { get; set; }

    /// <summary>
    /// A time value given in ISO8601 combined date and time format that represents when the Kubernetes cluster was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// A time value given in ISO8601 combined date and time format that represents when the Kubernetes cluster was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// An object containing a "state" attribute whose value is set to a string indicating the current status of the node. Potential values include running, provisioning, and errored.
    /// </summary>
    public KubernetesNodeStatus Status { get; set; }

    /// <summary>
    /// A string specifying the UUID of the VPC to which the Kubernetes cluster is assigned.
    /// </summary>
    public string VpcUuid { get; set; }
}