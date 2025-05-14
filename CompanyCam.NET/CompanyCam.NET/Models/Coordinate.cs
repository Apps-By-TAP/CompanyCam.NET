using System.Text.Json.Serialization;

namespace CompanyCam.NET.Models
{
    public class Coordinate
    {
        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lon")]
        public double Lon { get; set; }
    }
}
