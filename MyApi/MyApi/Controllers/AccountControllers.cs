using System.Security.Cryptography;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyApi.Entities;
using MyApi.Entities.Dto;
using MyApi.Entities.Dto.UserDto;
using MyApi.Extensions;
using MyApi.IServices;
using MyApi.Repository.IRepo;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ITokenServices tokenServices;
        public AccountController(IUnitOfWork unitOfWork, IMapper mapper, ITokenServices tokenServices)
        {
            this.tokenServices = tokenServices;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await unitOfWork.UserRepo.EmailExists(registerDto.Email))
            {
                return BadRequest("Email already exists");
            }
            var hmc = new HMACSHA512();
            var user = new AppUser
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                PasswordHash = hmc.ComputeHash(System.Text.Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmc.Key
            };
            await unitOfWork.UserRepo.CreateAsync(user);
            await unitOfWork.SaveAsync();
            return user.ToDto(tokenServices);

        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await unitOfWork.UserRepo.Get(x => x.Email == loginDto.Email);
            if (user == null)
            {
                return Unauthorized("Invalid Email");
            }
            var hmc = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmc.ComputeHash(System.Text.Encoding.UTF8.GetBytes(loginDto.Password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    return Unauthorized("Invalid Password");
                }
            }
            return user.ToDto(tokenServices);
        }

    }
}