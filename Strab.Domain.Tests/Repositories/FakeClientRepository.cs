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
            Task<IEnumerable<Client>> task = new Task<IEnumerable<Client>>(() => new List<Client>());
            task.Start();
            task.Wait();
            return task.Result;
        }

        public Client GetById(long id)
        {
            return new Client();
        }
    }
}