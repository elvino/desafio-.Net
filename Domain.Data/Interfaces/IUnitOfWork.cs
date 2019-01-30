using System;

namespace Domain.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
