using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using MyApi.Entities;
using MyApi.IServices;

namespace MyApi.Servicesdot
{
    public class TokenServices(IConfiguration config) : ITokenServices
    {
        public string CreateToken(AppUser user)
        {
            var tokenKey = config["TokenKey"] ?? throw new ArgumentNullException("TokenKey is null");
            if (tokenKey.Length == 64)
            {
                throw new ArgumentNullException("TokenKey is less than 64 characters");
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(tokenKey));
            var card = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = card
            };
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}