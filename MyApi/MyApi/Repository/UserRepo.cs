using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApi.Entities;
using MyApi.Repository.IRepo;

namespace MyApi.Repository
{
    public class UserRepo : Repository<AppUser>, IUserRepo
    {
        private readonly ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<bool> EmailExists(string email)
        {
            return await _context.Users
                .AnyAsync(u => u.Email == email);
        }

        public async Task UpdateAsync(AppUser user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
