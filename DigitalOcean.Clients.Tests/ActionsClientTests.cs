using DigitalOcean.Clients.Interfaces;

namespace DigitalOcean.Clients.Tests;

public class ActionsClientTests : ClientBaseTest<IActionsClient> {
    [Test]
    public async Task Test2() {
        var accountInfo = await Client.GetAll();

        Assert.That(accountInfo, Is.Not.Null);
    }
}

public class ReservedIpsClientTests : ClientBaseTest<IReservedIpsClient> {
    [Test]
    public async Task GetAllIps() {
        var reservedIps = await Client.GetAll();
        foreach (var reservedIp in reservedIps) {
                               Console.WriteLine(reservedIp);
        }
        Assert.That(reservedIps, Is.Not.Empty);
    }
}

public class DropletsClientTests : ClientBaseTest<IDropletsClient> {
    [Test]
    public async Task GetAllDroplets() {
        var droplets = (await Client.GetAll()).ToList();
        foreach (var droplet in droplets) {
            Console.WriteLine(droplet);
            var ipv4S = droplet.Networks.V4
                .Where(n => n.Type == "public")
                .Select(n => n.IpAddress)
                .Distinct()
                .ToList();
            Console.WriteLine(string.Join(' ', ipv4S));
        }
        Assert.That(droplets, Is.Not.Empty);
    }
}
