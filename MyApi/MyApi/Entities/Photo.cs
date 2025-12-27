

using System.ComponentModel.DataAnnotations.Schema;

namespace MyApi.Entities
{
    public class Photo
    {
        public int Id { get; set; }

        public required string Url { get; set; }

        // Changed from int? to string? (Cloudinary PublicIds are strings)
        public string? PublicId { get; set; }

        [ForeignKey("Member")]
        public string MemberId { get; set; }

        public Member Member { get; set; } = null!;
    }
}