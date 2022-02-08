using System.Collections.Generic;
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

        public IEnumerable<User> GetAll()
        {
            return new List<User>();
        }

        public User GetById(long id)
        {
            return new User();
        }

        public User Login(string email, string password)
        {
            return new User();
        }
    }
}