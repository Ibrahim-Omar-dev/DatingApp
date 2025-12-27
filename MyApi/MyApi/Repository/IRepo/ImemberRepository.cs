using MyApi.Entities;

namespace MyApi.Repository.IRepo
{
    public interface ImemberRepository : IRepository<Member>
    {
        public Task<IList<Photo>> GetPhotosFromMemberIdAsync(string memberId);
        void UpdateMember(Member member);
    }
}