using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyApi.Entities;

public class Member
{
    [Key]
    [ForeignKey("AppUser")]
    public string AppUserId { get; set; }

    public AppUser AppUser { get; set; } = null!;

    public string? UserName { get; set; }

    public DateOnly DateOfbirth { get; set; }

    public string? imageUrl { get; set; }

    public DateTime Created { get; set; } = DateTime.UtcNow;

    public DateTime LastActive { get; set; } = DateTime.UtcNow;

    public string? Description { get; set; }

    public required string Gender { get; set; }

    public required string City { get; set; }

    public required string Country { get; set; }

    public IList<Photo> photos { get; set; } = new List<Photo>();
}