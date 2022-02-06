using System;
using Microsoft.EntityFrameworkCore;
using Strab.Domain.Entities;
using Strab.Domain.Infra.Contexts;
using Strab.Domain.Repositories;

namespace Strab.Domain.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StrabContext _context;

        public UserRepository(StrabContext context)
        {
            _context = context;
        }

        public void Create(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Update(User entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(User entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.AsNoTracking().Where(x => x.Active == true).OrderBy(x => x.Email);
        }

        public User GetById(long id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public User Login(string email, string password)
        {
            return _context.Users
            .AsNoTracking()
            .Include(x => x.Role)
            .FirstOrDefault(x => x.Email == email && x.Password == password);
        }
    }
}