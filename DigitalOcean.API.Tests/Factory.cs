using System;

namespace DigitalOcean.API.Tests {
    public static class Factory {
        public static DigitalOceanClient GetClient() {
            return new DigitalOceanClient(Environment.GetEnvironmentVariable("DIGITALOCEAN_API_KEY"));
        }
    }
}