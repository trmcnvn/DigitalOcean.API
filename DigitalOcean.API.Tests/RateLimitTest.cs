using System.Threading.Tasks;
using Xunit;

namespace DigitalOcean.API.Tests {
    public class RateLimitTest {
        [Fact]
        public async Task ParsesRates() {
            var client = Factory.GetClient();
            await client.Actions.GetAll();

            Assert.NotNull(client.Rates);
            Assert.InRange(client.Rates.Remaining, 0, client.Rates.Limit);
        }
    }
}