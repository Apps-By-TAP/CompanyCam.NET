using System.Text.Json.Serialization;

namespace CompanyCam.NET.Models
{
    public class PhotoTag
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("company_id")]
        public string CompanyId { get; set; }
        [JsonPropertyName("display_value")]
        public string DisplayValue { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }
        [JsonPropertyName("created_at")]
        public int CreateAt { get; set; }
        [JsonPropertyName("updated_at")]
        public int UpdatedAt { get; set; }
        [JsonPropertyName("tag_type")]
        public string TagType { get; set; }
    }
}
