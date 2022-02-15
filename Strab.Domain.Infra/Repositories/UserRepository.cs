using System;
using Microsoft.EntityFrameworkCore;
using Strab.Domain.Entities;
using Strab.Domain.Infra.Contexts;
using Strab.Domain.Queries;
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
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(entity.Password);
            entity.SetHashedPassword(passwordHash);
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

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.AsNoTracking().Where(UserQueries.GetAllActive()).OrderBy(x => x.Email).ToListAsync();
        }

        public User GetById(long id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public async Task<User> Login(string email, string password)
        {
            var user = await _context.Users
                .AsNoTracking()
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Email == email);

            if (user != null)
            {
                bool verified = BCrypt.Net.BCrypt.Verify(password, user.Password);
                if (verified)
                    return user;
            }

            return null;
        }
    }
}