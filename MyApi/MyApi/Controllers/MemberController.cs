using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MyApi.Repository;
using MyApi.Repository.IRepo;
using MyApi.Entities.Dto.UserDto;
using Microsoft.AspNetCore.Authorization;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly ILogger<MemberController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MemberController(ILogger<MemberController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAllMembers")]
        public async Task<IActionResult> GetAllMembers()
        {
            var users = await _unitOfWork.UserRepo.GetAllAsync();
            var userDto = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(userDto);
        }
        [HttpGet("GetMemberByEmail/{Email}")]
        [Authorize]
        public async Task<IActionResult> GetMemberByEmail(string email)
        {
            var user = await _unitOfWork.UserRepo.Get(u => u.Email == email);
            if (user == null)
            {
                return NotFound();
            }
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }
    }
}
