using System.Collections.Generic;
using System.Threading.Tasks;
using Strab.Domain.Entities;
using Strab.Domain.Repositories;

namespace Strab.Domain.Tests.Repositories
{
    public class FakeUserRepository : IUserRepository
    {
        public void Create(User entity)
        {

        }

        public void Delete(User entity)
        {

        }

        public void Update(User entity)
        {

        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await Task.FromResult<IEnumerable<User>>(new List<User>());
        }

        public User GetById(long id)
        {
            return new User();
        }

        public async Task<User> Login(string email, string password)
        {
            return await Task.FromResult<User>(new User());
        }
    }
}