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
        public Coordinate Coordinate { get; set; }
        [JsonPropertyName("geofence")]
        public List<Coordinate> GeoFence { get; set; }
        [JsonPropertyName("primary_contact")]
        public Contact Contact { get; set; }
    }
}
