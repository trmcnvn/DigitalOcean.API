namespace DigitalOcean.API.Tests {
    public class Factory {
        public static DigitalOceanClient GetClient() {
            return new DigitalOceanClient("__TOKEN__");
        }
    }
}