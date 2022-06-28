using System;
using Microsoft.EntityFrameworkCore;
using Strab.Domain.Entities;
using Strab.Domain.Infra.Contexts;
using Strab.Domain.Queries;
using Strab.Domain.Repositories;

namespace Strab.Domain.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly StrabContext _context;

        public UserRepository(StrabContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.AsNoTracking().Where(UserQueries.GetAllActive()).OrderBy(x => x.Email).ToListAsync();
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