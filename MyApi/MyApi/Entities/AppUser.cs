
using System.ComponentModel.DataAnnotations;
using MyApi.Entities;

public class AppUser
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public required string UserName { get; set; }

    public string? imageUrl { get; set; }

    public required string Email { get; set; }

    public required byte[] PasswordHash { get; set; }

    public required byte[] PasswordSalt { get; set; }
    public Member? Member { get; set; }
}
