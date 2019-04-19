namespace DigitalOcean.API.Http {
    public interface IRateLimit {
        /// <summary>
        /// The number of requests that can be made per hour.
        /// </summary>
        int Limit { get; }

        /// <summary>
        /// The number of requests that remain before you hit your request limit.
        /// </summary>
        int Remaining { get; }

        /// <summary>
        /// This represents the time when the oldest request will expire. The value is given in Unix epoch time.
        /// </summary>
        int Reset { get; }
    }
}
