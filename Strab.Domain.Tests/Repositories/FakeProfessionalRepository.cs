using System.Collections.Generic;
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

        public IEnumerable<Professional> GetAll()
        {
            return new List<Professional>();
        }

        public Professional GetById(long id)
        {
            return new Professional();
        }
    }
}