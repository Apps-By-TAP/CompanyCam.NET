using System.Text.Json.Serialization;

namespace CompanyCam.NET.Models
{
    public class Address
    {
        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("postal_code")]
        public string PostalCode { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("street_address_1")]
        public string StreetAddress1 { get; set; }

        [JsonPropertyName("street_address_2")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string StreetAddress2 { get; set; }
    }
}
