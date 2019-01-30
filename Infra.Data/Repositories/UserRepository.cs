using System;
using System.Linq;
using Domain.Data.Entities;
using Domain.Data.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext _context;

        public UserRepository(DataBaseContext context)
        {
            _context = context;
        }

        public User Get(Guid id)
        {
            return _context
                .Users
                .Include(x => x.FirstName)
                .FirstOrDefault(x => x.Id == id);
        }

        public User GetByEmail(string mail)
        {
            return _context.Users
                .Include(e => e.Phones)
                .ThenInclude(e => e.User)
                .FirstOrDefault(x => x.Email == mail);
        }

        public void Save(User customer)
        {
            _context.Users.Add(customer);
        }

        public void Update(User customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }
    }
}
