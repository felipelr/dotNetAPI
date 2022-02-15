using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await Task.FromResult<IEnumerable<Role>>(new List<Role>());
        }

        public Role GetById(long id)
        {
            return new Role(1, "", "");
        }
    }
}