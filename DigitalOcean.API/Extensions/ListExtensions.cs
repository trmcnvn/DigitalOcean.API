using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalOcean.API.Extensions {
    public static class ListExtensions {
        public static Task<IReadOnlyList<T>> ToReadOnlyListAsync<T>(this Task<List<T>> listTask) {
            return listTask.ContinueWith(t => t.Result as IReadOnlyList<T>);
        }
    }
}
