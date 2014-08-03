using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using NSubstitute;
using RestSharp;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class ActionsTest {
        [Fact]
        public void CorrectRequestForGet() {
            var factory = Substitute.For<IConnection>();
            var actionClient = new ActionsClient(factory);

            actionClient.Get(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            factory.Received().ExecuteRequest<Action>("actions/{id}", parameters, null, "action");
        }

        [Fact]
        public void CorrectRequestForGetAll() {
            var factory = Substitute.For<IConnection>();
            var actionClient = new ActionsClient(factory);

            actionClient.GetAll();
            factory.Received().GetPaginated<Action>("actions", null, "actions");
        }

        [Fact]
        public async Task CorrectResponse() {
            var allIds = await Factory.GetClient().Actions.GetAll();
            Assert.NotEmpty(allIds);
            Assert.IsType<Action>(allIds[0]);
            Assert.Equal("completed", allIds[0].Status);

            var result = await Factory.GetClient().Actions.Get(allIds[0].Id);
            Assert.Equal(allIds[0].Id, result.Id);
        }
    }
}