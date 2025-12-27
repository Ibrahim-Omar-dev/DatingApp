using System.Text.Json.Serialization;

namespace MyApi.DTOs
{
    public class UserSeedDto
    {
        [JsonPropertyName("Id")]
        public string Id { get; set; }

        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("Gender")]
        public string Gender { get; set; }

        [JsonPropertyName("DateOfBirth")]
        public string DateOfBirth { get; set; }

        [JsonPropertyName("DisplayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("Created")]
        public string Created { get; set; }

        [JsonPropertyName("LastActive")]
        public string LastActive { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [JsonPropertyName("City")]
        public string City { get; set; }

        [JsonPropertyName("Country")]
        public string Country { get; set; }

        [JsonPropertyName("ImageUrl")]
        public string ImageUrl { get; set; }
    }
}