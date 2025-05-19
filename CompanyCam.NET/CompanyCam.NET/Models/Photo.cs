using System.Text.Json.Serialization;

namespace CompanyCam.NET.Models
{
    public class Photo
    {
        /// <summary>
        /// The unique ID for the photo.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// A unique ID for the Company that captured the Photo.
        /// </summary>
        [JsonPropertyName("company_id")]
        public string CompanyId { get; set; }

        /// <summary>
        /// The unique ID of the Entity that captured the Photo.
        /// </summary>
        [JsonPropertyName("creator_id")]
        public string CreatorId { get; set; }

        /// <summary>
        /// The type of Entity that captured the Photo.
        /// </summary>
        [JsonPropertyName("creator_type")]
        public string CreatorType { get; set; }

        /// <summary>
        /// The display name of the Entity that captured the Photo.
        /// </summary>
        [JsonPropertyName("creator_name")]
        public string CreatorName { get; set; }

        /// <summary>
        /// The unique ID of the project the Photo was captured at.
        /// </summary>
        [JsonPropertyName("project_id")]
        public string ProjectId { get; set; }

        /// <summary>
        /// Indicates the Photo’s processing status. It will be one of pending, processing, processed, processing_error, or duplicate.
        /// </summary>
        [JsonPropertyName("processing_status")]
        public string ProcessingStatus { get; set; }

        /// <summary>
        /// The coordinates where the Photo was captured.
        /// </summary>
        [JsonPropertyName("coordinates")]
        public Coordinate Coordinates { get; set; }

        /// <summary>
        /// A list of URIs for the different size variants of the photo. The list will have entries for original, web, and thumbnail. If the photo has been annotated, it will contain entries for original_annotation, web_annotation, and thumbnail_annotation.
        /// </summary>
        [JsonPropertyName("uris")]
        public ImageURI[] Uris { get; set; }

        /// <summary>
        /// The MD5 hash of the photo.
        /// </summary>
        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        /// <summary>
        /// The description of the Photo.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Indicates whether the photo is for internal use only and should not be used in marketing or other public materials.
        /// </summary>
        [JsonPropertyName("internal")]
        public bool Internal { get; set; }

        /// <summary>
        /// Timestamp when the Photo was captured.
        /// </summary>
        [JsonPropertyName("captured_at")]
        public int CapturedAt { get; set; }

        /// <summary>
        /// Timestamp when the photo was created on the server. This may differ from the captured_at field.
        /// </summary>
        [JsonPropertyName("created_at")]
        public int CreatedAt { get; set; }

        /// <summary>
        /// Timestamp when the photo was last updated.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public int UpdatedAt { get; set; }

        /// <summary>
        /// The link to the photo in the web app.
        /// </summary>
        [JsonPropertyName("photo_url")]
        public string PhotoUrl { get; set; }
    }
}
