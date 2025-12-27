namespace MyApi.Repository.IRepo
{
    public interface IUnitOfWork
    {
        IUserRepo UserRepo { get; }
        ImemberRepository MemberRepo { get; }
        Task SaveAsync();
    }
}