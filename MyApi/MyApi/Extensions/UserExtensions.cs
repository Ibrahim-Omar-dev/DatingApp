using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApi.Entities;
using MyApi.Entities.Dto.UserDto;
using MyApi.IServices;

namespace MyApi.Extensions
{
    public static class UserExtensions
    {
        public static UserDto ToDto(this AppUser user, ITokenServices token)
        {
            return new UserDto
            {
                Email = user.Email,
                UserName = user.UserName,
                Token = token.CreateToken(user)
            };
        }
    }
}