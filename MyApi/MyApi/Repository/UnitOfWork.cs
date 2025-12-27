using System;
using System.Threading.Tasks;
using MyApi.Repository.IRepo;

namespace MyApi.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserRepo _userRepo;
        private readonly ImemberRepository _memberRepo;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userRepo = new UserRepo(_context);
            _memberRepo = new MemberRepository(_context);
        }

        // Public properties to implement the interface
        public IUserRepo UserRepo => _userRepo;
        public ImemberRepository MemberRepo => _memberRepo;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        #region IDisposable
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}