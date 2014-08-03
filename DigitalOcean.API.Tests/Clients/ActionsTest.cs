using System.Collections.Generic;
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
    }
}