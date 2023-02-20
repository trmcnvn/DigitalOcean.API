using DigitalOcean.Clients.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalOcean.Clients.Tests;

public class AccountClientTests : ClientBaseTest<IAccountClient> {

    [Test]
    public async Task Test1() {
        var accountInfo = await Client.GetAsync();

        Assert.That(accountInfo, Is.Not.Null);
    }


}
