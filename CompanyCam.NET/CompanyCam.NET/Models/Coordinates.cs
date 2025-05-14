using System.Text.Json.Serialization;

namespace CompanyCam.NET.Models
{
    public class Coordinates
    {
        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lon")]
        public double Lon { get; set; }
    }
}
