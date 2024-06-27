using System.Text.Json.Serialization;

namespace RouterOSApiClient.REST.Types {
    public class NatRule {
        [JsonPropertyName(".id")]
        public string? Id { get; set; }

        [JsonPropertyName("action")]
        public string? Action { get; set; }

        [JsonPropertyName("bytes")]
        public string? Bytes { get; set; }

        [JsonPropertyName("chain")]
        public string? Chain { get; set; }

        [JsonPropertyName("comment")]
        public string? Comment { get; set; }

        [JsonPropertyName("disabled")]
        public string? Disabled { get; set; }

        [JsonPropertyName("dst-address")]
        public string? DstAddress { get; set; }

        [JsonPropertyName("dst-port")]
        public string? Dstport { get; set; }

        [JsonPropertyName("dynamic")]
        public string? Dynamic { get; set; }

        [JsonPropertyName("invalid")]
        public string? Invalid { get; set; }

        [JsonPropertyName("log")]
        public string? Log { get; set; }

        [JsonPropertyName("log-prefix")]
        public string? LogPrefix { get; set; }

        [JsonPropertyName("packets")]
        public string? Packets { get; set; }

        [JsonPropertyName("protocol")]
        public string? Protocol { get; set; }

        [JsonPropertyName("to-addresses")]
        public string? ToAddresses { get; set; }

        [JsonPropertyName("to-ports")]
        public string? ToPorts { get; set; }
    }
}
