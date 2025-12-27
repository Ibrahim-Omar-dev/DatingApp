using Microsoft.EntityFrameworkCore;
using MyApi.Entities;
using MyApi.Repository.IRepo;

namespace MyApi.Repository
{
    public class MemberRepository(ApplicationDbContext context) : Repository<Member>(context), ImemberRepository
    {
        // Fixed: Added async and await with ToListAsync()
        public async Task<IList<Photo>> GetPhotosFromMemberIdAsync(string memberId)
        {
            return await context.Members
                .Where(member => member.AppUserId == memberId)
                .SelectMany(member => member.photos)
                .ToListAsync();
        }

        public void UpdateMember(Member member)
        {
            context.Entry(member).State = EntityState.Modified;
        }
    }
}