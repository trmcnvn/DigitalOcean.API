using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;
using Xunit;

namespace DigitalOcean.API.Tests {
    public class ActionsTest {
        [Fact]
        public async Task GetSingle() {
            var result = await Factory.GetClient().Actions.Get(29644741);
            Assert.IsType<Action>(result);
            Assert.Equal("completed", result.Status);
        }

        [Fact]
        public async Task GetAll() {
            var result = await Factory.GetClient().Actions.GetAll();
            Assert.NotEmpty(result);
            Assert.IsType<Action>(result[0]);
            Assert.Equal("completed", result[0].Status);
        }
    }
}