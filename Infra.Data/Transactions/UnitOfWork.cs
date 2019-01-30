using Domain.Data.Interfaces;
using Infra.Data.Context;

namespace Infra.Data.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _context;

        public UnitOfWork(DataBaseContext context) => _context = context;

        public bool Commit() => _context.SaveChanges() > 0;

        public void Dispose() => _context.Dispose();
    }
}
