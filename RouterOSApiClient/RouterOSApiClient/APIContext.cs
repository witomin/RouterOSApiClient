namespace RouterOSApiClient {
    public class APIContext {
        public APIContext(APIConfig config) {
            Config = config;
        }
        public APIConfig Config { get; private set; }
    }
}
