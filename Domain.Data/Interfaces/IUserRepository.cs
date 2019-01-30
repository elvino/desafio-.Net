using System;
using Domain.Data.Entities;

namespace Domain.Data.Interfaces
{
    public interface IUserRepository
    {
        User Get(Guid id);
        User GetByEmail(string username);
        void Save(User customer);
        void Update(User customer);  
    }
}
