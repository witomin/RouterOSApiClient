namespace RouterOSApiClient {
    public abstract class API {
        public API(APIContext context) {
            Context = context;
        }

        public APIContext Context { get; private set; }

    }
}
