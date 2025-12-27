using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using MyApi.DTOs;
using MyApi.Entities;

namespace MyApi.Data
{
    public class Seed
    {
        public static async Task SeedUsers(ApplicationDbContext context)
        {
            // Check if users already exist
            if (await context.Users.AnyAsync()) return;

            // Read the JSON file
            var userData = await File.ReadAllTextAsync("Data/UserSeedData.json");

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var users = JsonSerializer.Deserialize<List<UserSeedDto>>(userData, options);

            if (users == null || users.Count == 0) return;

            foreach (var userDto in users)
            {
                // Create password hash and salt (using default password "Pa$$w0rd")
                using var hmac = new HMACSHA512();

                var user = new AppUser
                {
                    Id = userDto.Id,
                    UserName = userDto.DisplayName.ToLower(),
                    Email = userDto.Email,
                    imageUrl = userDto.ImageUrl,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd")),
                    PasswordSalt = hmac.Key
                };

                var member = new Member
                {
                    AppUserId = user.Id,
                    UserName = userDto.DisplayName,
                    DateOfbirth = DateOnly.Parse(userDto.DateOfBirth),
                    imageUrl = userDto.ImageUrl,
                    Created = DateTime.Parse(userDto.Created),
                    LastActive = DateTime.Parse(userDto.LastActive),
                    Description = userDto.Description,
                    Gender = userDto.Gender,
                    City = userDto.City,
                    Country = userDto.Country,
                    AppUser = user
                };

                // Add a photo from the ImageUrl
                var photo = new Photo
                {
                    Url = userDto.ImageUrl,
                    MemberId = member.AppUserId,
                    Member = member
                };

                member.photos.Add(photo);
                user.Member = member;

                context.Users.Add(user);
            }

            await context.SaveChangesAsync();
        }
    }
}