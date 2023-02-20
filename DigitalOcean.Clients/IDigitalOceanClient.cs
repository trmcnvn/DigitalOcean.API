namespace DigitalOcean.Clients;

public interface IDigitalOceanClient {
    IAccountClient Account { get; }
    IActionsClient Actions { get; }

    IRateLimit Rates { get; }
}
