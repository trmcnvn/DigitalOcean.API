using DigitalOcean.Clients.Interfaces;

namespace DigitalOcean.Clients.Tests;

public class BalanceClientTests : ClientBaseTest<IBalanceClient> {

    [Test]
    public async Task GetAccountBalance_ValidApiKey_ShouldSucceed() {

        var balance = await Client.GetAsync();
        Assert.That(balance.AccountBalance, Is.Not.Empty);
    }
}
