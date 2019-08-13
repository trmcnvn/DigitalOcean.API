using System.Collections.Generic;

namespace DigitalOcean.API.Models.Responses {
    public class KubernetesOptions {
        /// <summary>
        /// An array containing sets of "kubernetes_version" and "slug" attributes corresponding to an available version of Kubernetes.
        /// </summary>
        public List<KubernetesVersionOption> Versions { get; set; }

        /// <summary>
        ///
        /// </summary>
        public List<KubernetesRegionOption> Regions { get; set; }

        /// <summary>
        ///
        /// </summary>
        public List<KubernetesSizeOption> Sizes { get; set; }

        public class KubernetesVersionOption {
            /// <summary>
            /// The identifier for an available version of Kubernetes for use when creating a new cluster. The string contains both the upstream version of Kubernetes as well as the DigitalOcean revision.
            /// </summary>
            public string Slug { get; set; }

            /// <summary>
            /// The upstream version of Kubernetes provided by a given slug.
            /// </summary>
            public string KubernetesVersion { get; set; }
        }

        public class KubernetesRegionOption {
            /// <summary>
            /// A DigitalOcean region where Kubernetes is available.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// The identifier for a region for use when creating a new cluster.
            /// </summary>
            public string Slug { get; set; }
        }

        public class KubernetesSizeOption {
            /// <summary>
            /// A Droplet size available for use in a Kubernetes node pool.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            ///  The identifier for a size for use when creating a new cluster.
            /// </summary>
            public string Slug { get; set; }
        }
    }
}
