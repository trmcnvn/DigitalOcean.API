using RestSharp;

namespace DigitalOcean.API.Requests {
    public class Request {
        public IRestClient RestClient { get; private set; }

        public Request(IRestClient restClient) {
            RestClient = restClient;
        }
    }
}