using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DigitalOcean.API.Extensions {
    public static class ListExtensions {
        public static Task<IReadOnlyList<T>> ToReadOnlyListAsync<T>(this Task<List<T>> listTask) {
            return listTask.ContinueWith(t => t.Result?.AsReadOnly() ?? (IReadOnlyList<T>)new ReadOnlyCollection<T>(new List<T>(0)));
        }
    }
}
