using System;
using System.Threading.Tasks;
using MyApi.Repository.IRepo;   // IUnitOfWork, IUserRepo

namespace MyApi.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private IUserRepo? _userRepo;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IUserRepo UserRepo => _userRepo ??= new UserRepo(_context);

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
