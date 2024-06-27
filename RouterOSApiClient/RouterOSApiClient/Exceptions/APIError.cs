using System.Text.Json;
using System.Text.Json.Serialization;

namespace RouterOSApiClient.Exceptions
{
    public class APIError
    {
        [JsonPropertyName("detail")]
        public string Detail { get; set; }

        [JsonPropertyName("error")]
        public int Error { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        public override string ToString() {
            return JsonSerializer.Serialize(this);
        }
    }
}
