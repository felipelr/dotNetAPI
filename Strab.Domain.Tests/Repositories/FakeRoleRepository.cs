using System.Collections.Generic;
using Strab.Domain.Entities;
using Strab.Domain.Repositories;

namespace Strab.Domain.Tests.Repositories
{
    public class FakeRoleRepository : IRoleRepository
    {
        public void Create(Role entity)
        {

        }

        public void Delete(Role entity)
        {

        }

        public void Update(Role entity)
        {

        }

        public IEnumerable<Role> GetAll()
        {
            return new List<Role>();
        }

        public Role GetById(long id)
        {
            return new Role(1, "", "");
        }
    }
}