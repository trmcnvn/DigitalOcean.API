using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;
using RestSharp;
using RestSharp.Deserializers;

namespace DigitalOcean.API.Helpers {
    public class Paginated {
        private readonly IConnection _connection;

        public Paginated(IConnection connection) {
            _connection = connection;
        }

        public async Task<IReadOnlyList<T>> GetPaginated<T>(string endpoint, IList<Parameter> parameters,
            string expectedRoot = null)
            where T : new() {
            var first = await _connection.GetRequestRaw(endpoint, parameters).ConfigureAwait(false);
            return await ParseData<T>(first, expectedRoot).ConfigureAwait(false);
        }

        private async Task<IReadOnlyList<T>> ParseData<T>(IRestResponse response, string expectedRoot) {
            // get page information
            var deserialize = new JsonDeserializer {
                RootElement = "links",
                DateFormat = response.Request.DateFormat
            };
            var page = deserialize.Deserialize<Pagination>(response);

            // get intial data
            deserialize.RootElement = expectedRoot;
            var data = deserialize.Deserialize<List<T>>(response);

            // loop until we are finished
            var allItems = new List<T>(data);
            while (!String.IsNullOrWhiteSpace(page.Pages.Next)) {
                var endpoint = page.Pages.Next.Replace(DigitalOceanClient.DigitalOceanApiUrl, "");
                var iter = await _connection.GetRequestRaw(endpoint, null).ConfigureAwait(false);

                deserialize.RootElement = expectedRoot;
                allItems.AddRange(deserialize.Deserialize<List<T>>(iter));

                deserialize.RootElement = "links";
                page = deserialize.Deserialize<Pagination>(iter);
            }
            return new ReadOnlyCollection<T>(allItems);
        }
    }
}