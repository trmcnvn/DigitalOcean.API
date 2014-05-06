using System.Threading.Tasks;
using DigitalOcean.API.Helpers;
using DigitalOcean.API.Responses;
using RestSharp;

namespace DigitalOcean.API.Requests {
    public interface IEventsClient {
        /// <summary>
        /// This method is primarily used to report on the progress of an event by providing the percentage of completion
        /// </summary>
        /// <param name="eventId">id of the event you would like more information about</param>
        Task<Event> GetEvent(int eventId);
    }

    public class EventsClient : Request, IEventsClient {
        public EventsClient(IRestClient restClient) : base(restClient) {}

        #region IEventsClient Members

        public async Task<Event> GetEvent(int eventId) {
            var req = new RestRequest("events/{id}");
            req.AddParameter("id", eventId, ParameterType.UrlSegment);
            var ret = await RestClient.ExecuteTask<Event>(req);
            return ret.Data;
        }

        #endregion
    }
}