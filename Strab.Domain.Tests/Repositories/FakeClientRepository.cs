using System.Collections.Generic;
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

        public IEnumerable<Client> GetAll()
        {
            return new List<Client>();
        }

        public Client GetById(long id)
        {
            return new Client();
        }
    }
}