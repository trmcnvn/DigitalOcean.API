using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Responses;
using NSubstitute;
using Xunit;

namespace DigitalOcean.API.Tests.Clients {
    public class SizesClientTest {
        [Fact]
        public void CorrectRequestForGetAll() {
            var factory = Substitute.For<IConnection>();
            var client = new SizesClient(factory);

            client.GetAll();

            factory.Received().GetPaginated<Size>("sizes", null, "sizes");
        }
    }
}
