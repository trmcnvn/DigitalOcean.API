using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
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
            factory.Received().GetPaginated<DomainRecord>("domains/{name}/records", parameters, "domain_records");
        }

        [Fact]
        public void CorrectRequireForCreate() {
            var factory = Substitute.For<IConnection>();
            var domainClient = new DomainRecordsClient(factory);

            var data = new Models.Requests.DomainRecord { Name = "CNAME" };
            domainClient.Create("vevix.net", data);

            var parameters = Arg.Is<List<Parameter>>(list => (string)list[0].Value == "vevix.net");
            factory.Received()
                .ExecuteRequest<DomainRecord>("domains/{name}/records", parameters, data,
                    "domain_record", Method.POST);
        }

        [Fact]
        public void CorrectRequestForGet() {
            var factory = Substitute.For<IConnection>();
            var domainClient = new DomainRecordsClient(factory);

            domainClient.Get("vevix.net", 9001);

            var parameters = Arg.Is<List<Parameter>>(list =>
                (string)list[0].Value == "vevix.net" && (int)list[1].Value == 9001);
            factory.Received()
                .ExecuteRequest<DomainRecord>("domains/{name}/records/{id}", parameters,
                    null, "domain_record");
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
            factory.Received().ExecuteRequest<DomainRecord>(
                "domains/{name}/records/{id}", parameters, data, "domain_record", Method.PUT);
        }
    }
}