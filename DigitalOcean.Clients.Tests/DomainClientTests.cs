using DigitalOcean.Clients.Interfaces;

namespace DigitalOcean.Clients.Tests;

public class DomainClientTests : ClientBaseTest<IDomainsClient> {

    [Test]
    public async Task GetAllDomains_ShouldSucceed() {
        var domains = await Client.GetAllAsync();
        foreach (var domain in domains) {
            Assert.That(domain, Is.Not.Null);
            Assert.Multiple(() => {
                Assert.That(domain.Name, Is.Not.Empty);
                Assert.That(domain.ZoneFile, Is.Not.Empty);
            });
        }
    }
}
