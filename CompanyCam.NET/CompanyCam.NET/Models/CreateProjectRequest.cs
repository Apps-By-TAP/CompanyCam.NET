using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CompanyCam.NET.Models
{
    public class CreateProjectRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("address")]
        public Address Address { get; set; }
        [JsonPropertyName("coordinates")]
        public Coordinates Coordinates { get; set; }
        [JsonPropertyName("geofence")]
        public List<Coordinates> GeoFence { get; set; }
        [JsonPropertyName("primary_contact")]
        public Contact Contact { get; set; }
    }
}
