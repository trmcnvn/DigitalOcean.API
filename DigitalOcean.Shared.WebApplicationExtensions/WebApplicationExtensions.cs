namespace DigitalOcean.Shared.WebApplicationExtensions;

public static class WebApplicationExtensions {
    public static IServiceCollection AddDigitalOcean(this IServiceCollection builder, Action<DigitalOceanApiOptions>? configureOptions = null) {
        DigitalOceanApiOptions digitalOceanOptions = new ();
        configureOptions?.Invoke(digitalOceanOptions);
        builder.AddHttpClient<IConnection, Connection>("DigitalOcean")
            .ConfigureHttpClient(c => {
                c.BaseAddress = new Uri(DigitalOceanClient.DIGITAL_OCEAN_API_URL);
            });

        builder.AddTransient<IAccountClient, AccountClient>();
        builder.AddTransient<IActionsClient, ActionsClient>();
        builder.AddTransient<IDomainsClient, DomainsClient>();
        builder.AddTransient<IBalanceClient, BalanceClient>();
        builder.AddTransient<IDropletsClient, DropletsClient>();
        builder.AddTransient<IDomainRecordsClient, DomainRecordsClient>();
        builder.AddTransient<IReservedIpsClient, ReservedIpsClient>();
        builder.AddTransient<IKeysClient, KeysClient>();
        builder.AddTransient<ICertificatesClient, CertificatesClient>();
        builder.AddTransient<IFloatingIpActionsClient, FloatingIpActionsClient>();
        return builder;
    }

    public static WebApplicationBuilder AddDigitalOcean(this WebApplicationBuilder builder, Action<DigitalOceanApiOptions>? config = null) {
        if (builder.Configuration.GetValue<bool>("DigitalOcean:IsEnabled")) {
            builder.Services.AddDigitalOcean();
            builder.Services.Configure<DigitalOceanApiOptions>(opt => {
                config?.Invoke(opt);
                opt.ApiKey ??= builder.Configuration["DigitalOcean:ApiKey"];
            });;

        }

        return builder;
    }
}
