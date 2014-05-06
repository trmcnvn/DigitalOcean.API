namespace DigitalOcean.API.Responses {
    public class EventPtr {
        public string status { get; set; }
        public int event_id { get; set; }
    }

    public class EventInfo {
        public int id { get; set; }
        public string action_status { get; set; }
        public int droplet_id { get; set; }
        public int event_type_id { get; set; }
        public string percentage { get; set; }
    }

    public class Event {
        public string status { get; set; }
        public EventInfo @event { get; set; }
    }
}