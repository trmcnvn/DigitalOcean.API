using DigitalOcean.Clients.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DigitalOcean.Clients.Tests;

public class ClientBaseTest<T> where T : class {
    private string _apiKey = "dop_v1_d687c4289c9f6f985e008f324b4729670f335ae8f54f946d7e326a6df25ced74";

    protected T Client;

    [SetUp]
    public void Initialize() {
        var app = Host.CreateDefaultBuilder();
        app = app.ConfigureServices(services => services.AddAllClients(_apiKey)
            .AddLogging(builder => builder.AddConsole().AddFilter(f => f == LogLevel.Debug)));
        Client = app.Build().Services.GetRequiredService<T>();
    }
}
