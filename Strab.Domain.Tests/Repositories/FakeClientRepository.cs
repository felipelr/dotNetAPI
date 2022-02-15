using System.Collections.Generic;
using System.Threading.Tasks;
using Strab.Domain.Entities;
using Strab.Domain.Repositories;

namespace Strab.Domain.Tests.Repositories
{
    public class FakeClientRepository : IClientRepository
    {
        public void Create(Client entity)
        {

        }

        public void Delete(Client entity)
        {

        }

        public void Update(Client entity)
        {

        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await Task.FromResult<IEnumerable<Client>>(new List<Client>());
        }

        public Client GetById(long id)
        {
            return new Client();
        }
    }
}