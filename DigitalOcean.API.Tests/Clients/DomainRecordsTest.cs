using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Helpers;
using DigitalOcean.API.Models.Responses;
using NSubstitute;
using RestSharp;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class DomainRecordsTest {
        [Fact]
        public void CorrectRequestForGetAll() {
            var factory = Substitute.For<IConnection>();
            var domainClient = new DomainRecordsClient(factory);

            domainClient.GetAll("vevix.net");

            var parameters = Arg.Is<List<Parameter>>(list => 
                (string)list[0].Value == "vevix.net");
            factory.Received().ExecuteRaw("domains/{name}/records", parameters);
        }

        [Fact]
        public void CorrectRequireForCreate() {
            var factory = Substitute.For<IConnection>();
            var domainClient = new DomainRecordsClient(factory);

            var data = new Models.Requests.DomainRecord { Name = "CNAME" };
            domainClient.Create("vevix.net", data);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "vevix.net");
            factory.Received().PostRequest<DomainRecord>("domains/{name}/records", parameters, data, "domain_record");
        }

        [Fact]
        public void CorrectRequestForGet() {
            var factory = Substitute.For<IConnection>();
            var domainClient = new DomainRecordsClient(factory);

            domainClient.Get("vevix.net", 9001);

            var parameters = Arg.Is<List<Parameter>>(list => 
                (string)list[0].Value == "vevix.net" && (int)list[1].Value == 9001);
            factory.Received().GetRequest<DomainRecord>("domains/{name}/records/{id}", parameters, "domain_record");
        }

        [Fact]
        public void CorrectRequestForDelete() {
            var factory = Substitute.For<IConnection>();
            var domainClient = new DomainRecordsClient(factory);

            domainClient.Delete("vevix.net", 9001);

            var parameters = Arg.Is<List<Parameter>>(list => 
                (string)list[0].Value == "vevix.net" && (int)list[1].Value == 9001);
            factory.Received().ExecuteRaw("domains/{name}/records/{id}", parameters, Method.DELETE);
        }

        [Fact]
        public void CorrectRequestForUpdate() {
            var factory = Substitute.For<IConnection>();
            var domainClient = new DomainRecordsClient(factory);

            var data = new Models.Requests.DomainRecord { Name = "CNAME" };
            domainClient.Update("vevix.net", 9001, data);

            var parameters = Arg.Is<List<Parameter>>(list => 
                (string)list[0].Value == "vevix.net" && (int)list[1].Value == 9001);
            factory.Received().PostRequest<DomainRecord>(
                "domains/{name}/records/{id}", parameters, data, "domain_record", Method.PUT);
        }

        [Fact]
        public async Task CorrectResponseForGet() {
            var allIds = await Factory.GetClient().DomainRecords.GetAll("vevix.net");
            Assert.NotEmpty(allIds);
            Assert.IsType<DomainRecord>(allIds[0]);
            Assert.Equal("@", allIds[0].Name);

            var result = await Factory.GetClient().DomainRecords.Get("vevix.net", allIds[0].Id);
            Assert.Equal(allIds[0].Id, result.Id);
        }

        [Fact]
        public async Task CorrectResponseForCreateUpdateDelete() {
            var body = new Models.Requests.DomainRecord {
                Type = "CNAME",
                Name = "testing",
                Data = "testing.example.com."
            };
            var create = await Factory.GetClient().DomainRecords.Create("vevix.net", body);
            Assert.Equal("testing", create.Name);
            Assert.Equal("CNAME", create.Type);

            body.Name = "updated_testing";
            var update = await Factory.GetClient().DomainRecords.Update("vevix.net", create.Id, body);
            Assert.Equal("updated_testing", update.Name);

            await Factory.GetClient().DomainRecords.Delete("vevix.net", update.Id);
        }
    }
}