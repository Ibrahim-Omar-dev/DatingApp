using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApi.Entities;

namespace MyApi.IServices
{
    public interface ITokenServices
    {
        public string CreateToken(AppUser user);
    }
}