using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Entities.Dto.UserDto
{
    public class UserDto
    {
        public required string UserName { get; set; }

        public string? imageUrl { get; set; }

        public required string Email { get; set; }
        public required string Token { get; set; }
    }
}