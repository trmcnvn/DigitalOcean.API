using System.Net;
using DigitalOcean.Clients.Interfaces;
using DigitalOcean.Clients.Models.Requests;

namespace DigitalOcean.Clients.Tests;

public class DomainRecordsTests : ClientBaseTest<IDomainRecordsClient> {
    private const string _ricardoalcarazDev = "ricardoalcaraz.dev";

    [Test]
    public async Task GetDomainRecords() {
        var records = await Client.GetAllAsync(_ricardoalcarazDev);
        Assert.That(records, Is.Not.Empty);
    }

    [Test]
    public async Task CreateAndDeleteDomainRecord() {
        var ip = IPAddress.Parse("107.138.173.152").ToString();
        var record = new DomainRecord {
            Type = "A",
            Name = "test",
            Data = ip
        };

        var response = await Client.Create(_ricardoalcarazDev, record);
        var singleRecord = await Client.Get(_ricardoalcarazDev, response.Id);

        Assert.That(response, Is.EqualTo(singleRecord));
        await Client.Delete(_ricardoalcarazDev, response.Id);

        Assert.That(response.Id, Is.GreaterThan(0));
    }

    [Test]
    public async Task UpdateDomainRecord() {
        var ip = IPAddress.Parse("107.138.173.152").ToString();
        var record = new DomainRecord {
            Type = "A",
            Name = "test",
            Data = ip
        };

        var re = await Client.Create(_ricardoalcarazDev, record);

        var updateRecord = new UpdateDomainRecord() {
            Type = re.Type,
            Name = "other",
            Data = re.Data
        };

        var updateResponse = await Client.Update(_ricardoalcarazDev, re.Id, updateRecord);
        await Client.Delete(_ricardoalcarazDev, updateResponse.Id);
        Assert.That(updateResponse.Id, Is.GreaterThan(0));
        Assert.That(updateResponse.Id, Is.EqualTo(re.Id));
    }
}
