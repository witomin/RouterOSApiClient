using RouterOSApiClient.Exceptions;
using System.Net;
using System.Net.Http.Json;

namespace RouterOSApiClient {
    /// <summary>
    /// Ответ API
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public class APIResponse<TResult> {
        public TResult? ResultObject { get; private set; }
        public string? ResultStr { get; private set; }
        public static async Task<APIResponse<TResult>> ReadApiResponseAsync(HttpResponseMessage response) {
            APIResponse<TResult> ret = new APIResponse<TResult>();
            if (response.StatusCode == HttpStatusCode.OK) {
                if (response.Content != null) {
                    ret.ResultStr = await response.Content.ReadAsStringAsync();
                    ret.ResultObject = await response.Content.ReadFromJsonAsync<TResult>();
                }
            }
            else {
                APIError? Error = null;
                if (response.Content != null) {
                    Error = await response.Content.ReadFromJsonAsync<APIError>();
                    throw new APIRequestException(response.StatusCode, Error);
                }
                throw new APIRequestException(response.ReasonPhrase, response.StatusCode);
            }
            return ret;
        }
    }
}
