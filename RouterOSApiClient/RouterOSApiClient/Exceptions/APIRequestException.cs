using System.Net;

namespace RouterOSApiClient.Exceptions {
    public class APIRequestException : Exception {
        public HttpStatusCode? HttpStatusCode { get; set; }
        public APIError ErorrData { get; set; }
        public APIRequestException(HttpStatusCode httpStatusCode, APIError failedAPIResponse) : base(failedAPIResponse.ToString()) {
            HttpStatusCode = httpStatusCode;
            ErorrData = failedAPIResponse;
        }
        public APIRequestException(string message, HttpStatusCode httpStatusCode) : base(message) {
            HttpStatusCode = httpStatusCode;
        }
    }
}
