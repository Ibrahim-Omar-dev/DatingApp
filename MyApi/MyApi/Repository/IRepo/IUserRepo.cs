using MyApi.Entities;

namespace MyApi.Repository.IRepo
{
    public interface IUserRepo : IRepository<AppUser>
    {
        Task UpdateAsync(AppUser user);
        public Task<bool> EmailExists(string email);
    }
}