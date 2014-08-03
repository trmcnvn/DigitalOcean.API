using System.Threading.Tasks;
using DigitalOcean.API.Models.Responses;
using Xunit;

namespace DigitalOcean.API.Tests {
    public class DomainRecordsTest {
        [Fact]
        public async Task GetSingle() {
            var result = await Factory.GetClient().DomainRecords.Get("vevix.net", 1);
            Assert.Equal("@", result.Name);
        }

        [Fact]
        public async Task GetAll() {
            var result = await Factory.GetClient().DomainRecords.GetAll("vevix.net");
            Assert.NotEmpty(result);
            Assert.IsType<DomainRecord>(result[0]);
            Assert.Equal("@", result[0].Name);
        }

        [Fact]
        public async Task CreateAndDelete() {
            var body = new Models.Requests.DomainRecord {
                Type = "CNAME",
                Name = "testing",
                Data = "testing.test.com."
            };
            var create = await Factory.GetClient().DomainRecords.Create("vevix.net", body);
            Assert.Equal(create.Name, "testing");
            Assert.Equal(create.Type, "CNAME");

            await Factory.GetClient().DomainRecords.Delete("vevix.net", create.Id);
        }
    }
}