using System.Collections.Generic;

namespace DigitalOcean.API.Responses {
    public class SshInfo {
        public int id { get; set; }
        public string name { get; set; }
        public string ssh_pub_key { get; set; }
    }

    public class SshKeys {
        public string status { get; set; }
        public IList<SshInfo> ssh_keys { get; set; }
    }

    public class SshKey {
        public string status { get; set; }
        public SshInfo ssh_key { get; set; }
    }
}