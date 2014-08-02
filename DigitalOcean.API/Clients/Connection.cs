using RestSharp;

namespace DigitalOcean.API.Clients {
    public class Connection {
        public IRestClient Client { get; private set; }

        public Connection(IRestClient client) {
            Client = client;
        }
    }
}