namespace MyApi.Repository.IRepo
{
    public interface IUnitOfWork
    {
        IUserRepo UserRepo { get; }
        Task SaveAsync();
    }
}