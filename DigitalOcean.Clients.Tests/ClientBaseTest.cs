using DigitalOcean.Shared.WebApplicationExtensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DigitalOcean.Clients.Tests;

public class ClientBaseTest<T> where T : class {
    protected T Client;

    [SetUp]
    public void Initialize() {
        var app = Host.CreateDefaultBuilder();
        app = app.ConfigureServices(services => services.AddDigitalOcean()
            .AddLogging(builder => builder.AddConsole().AddFilter(f => f == LogLevel.Debug)));
        Client = app.Build().Services.GetRequiredService<T>();
    }
}
