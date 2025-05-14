using System.Text.Json.Serialization;

namespace CompanyCam.NET.Models
{
    public class FeatureImage
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("uri")]
        public string Uri { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
