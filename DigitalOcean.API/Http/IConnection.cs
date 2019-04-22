using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace DigitalOcean.API.Http {
    public interface IConnection {
        IRestClient Client { get; }
        IRateLimit Rates { get; }

        Task<IRestResponse> ExecuteRaw(string endpoint, IList<Parameter> parameters, object data = null, Method method = Method.GET);

        Task<T> ExecuteRequest<T>(string endpoint, IList<Parameter> parameters,
            object data = null, string expectedRoot = null, Method method = Method.GET) where T : new();

        Task<IReadOnlyList<T>> GetPaginated<T>(string endpoint, IList<Parameter> parameters,
            string expectedRoot = null) where T : new();
    }
}
