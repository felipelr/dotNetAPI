using System;
using Strab.Domain.Entities;
using Strab.Domain.Repositories;

namespace Strab.Domain.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        public void Save(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(long id)
        {
            throw new NotImplementedException();
        }
    }
}