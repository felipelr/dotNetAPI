using System.Collections.Generic;
using System.Threading.Tasks;
using Strab.Domain.Entities;
using Strab.Domain.Repositories;

namespace Strab.Domain.Tests.Repositories
{
    public class FakeProfessionalRepository : IProfessionalRepository
    {
        public void Create(Professional entity)
        {

        }

        public void Delete(Professional entity)
        {

        }

        public void Update(Professional entity)
        {

        }

        public async Task<IEnumerable<Professional>> GetAll()
        {
            Task<IEnumerable<Professional>> task = new Task<IEnumerable<Professional>>(() => new List<Professional>());
            task.Start();
            task.Wait();
            return task.Result;
        }

        public Professional GetById(long id)
        {
            return new Professional();
        }
    }
}