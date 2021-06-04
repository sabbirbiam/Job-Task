using System;
using System.Threading.Tasks;

namespace m2sys.core
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
