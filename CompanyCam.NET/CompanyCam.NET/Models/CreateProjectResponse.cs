using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CompanyCam.NET.Models
{
    public class CreateProjectResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("company_id")]
        public string CompanyId { get; set; }

        [JsonPropertyName("creator_id")]
        public string CreatorId { get; set; }

        [JsonPropertyName("creator_type")]
        public string CreatorType { get; set; }

        [JsonPropertyName("creator_name")]
        public string CreatorName { get; set; }

        [JsonPropertyName("integration_relation_id")]
        public string IntegrationRelationId { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("archived")]
        public bool Archived { get; set; }

        [JsonPropertyName("public")]
        public bool Public { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonPropertyName("feature_image")]
        public List<object> FeatureImage { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("project_url")]
        public string ProjectUrl { get; set; }

        [JsonPropertyName("public_url")]
        public string PublicUrl { get; set; }

        [JsonPropertyName("coordinates")]
        public Coordinate Coordinates { get; set; }

        [JsonPropertyName("geofence")]
        public List<object> Geofence { get; set; }

        [JsonPropertyName("primary_contact")]
        public Contact PrimaryContact { get; set; }

        [JsonPropertyName("created_at")]
        public long CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public long UpdatedAt { get; set; }

        [JsonPropertyName("embedded_project_url")]
        public string EmbeddedProjectUrl { get; set; }

        [JsonPropertyName("photo_count")]
        public int PhotoCount { get; set; }

        [JsonPropertyName("capture_photo_deeplink")]
        public string CapturePhotoDeeplink { get; set; }

        [JsonPropertyName("integrations")]
        public List<object> Integrations { get; set; }

        [JsonPropertyName("notepad")]
        public string Notepad { get; set; }

        public bool Success { get; set; }
        public string Error { get; set; }
    }
}
