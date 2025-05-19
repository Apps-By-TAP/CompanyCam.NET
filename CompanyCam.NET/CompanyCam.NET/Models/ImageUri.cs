using System.Text.Json.Serialization;

namespace CompanyCam.NET.Models
{
    public class ImageURI
    {
        /// <summary>
        /// The type of the URI, for example "original" or "thumbnail".
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The full URI of the image.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }

        /// <summary>
        /// The full URL of the image.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
