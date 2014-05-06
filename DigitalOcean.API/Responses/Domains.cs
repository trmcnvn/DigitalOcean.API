using System.Collections.Generic;

namespace DigitalOcean.API.Responses {
    public class DomainInfo {
        public int id { get; set; }
        public string name { get; set; }
        public int ttl { get; set; }
        public string live_zone_file { get; set; }
        public object error { get; set; }
        public object zone_file_with_error { get; set; }
    }

    public class Domains {
        public string status { get; set; }
        public IList<DomainInfo> domains { get; set; }
    }

    public class Domain {
        public string status { get; set; }
        public DomainInfo domain { get; set; }
    }

    public class NewDomainInfo {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class NewDomain {
        public string status { get; set; }
        public NewDomainInfo domain { get; set; }
    }

    public class DomainRecordInfo {
        public int id { get; set; }
        public string domain_id { get; set; }
        public string record_type { get; set; }
        public string name { get; set; }
        public string data { get; set; }
        public int priority { get; set; }
        public int port { get; set; }
        public int weight { get; set; }
    }

    public class DomainRecords {
        public string status { get; set; }
        public IList<DomainRecordInfo> records { get; set; }
    }

    public class DomainRecord {
        public string status { get; set; }
        public DomainRecordInfo record { get; set; }
    }

    public class NewDomainRecord {
        public string status { get; set; }
        public DomainRecordInfo domain_record { get; set; }
    }
}