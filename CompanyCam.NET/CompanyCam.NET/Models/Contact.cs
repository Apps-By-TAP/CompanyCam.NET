using System.Text.Json.Serialization;

namespace CompanyCam.NET.Models
{
    public class Contact
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("company_id")]
        public string CompanyId { get; set; }

        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("created_at")]
        public int CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public int UpdatedAt { get; set; }
    }
}
