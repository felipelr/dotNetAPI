using System;
using Microsoft.EntityFrameworkCore;
using Strab.Domain.Entities;
using Strab.Domain.Infra.Contexts;
using Strab.Domain.Repositories;

namespace Strab.Domain.Infra.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly StrabContext _context;

        public ClientRepository(StrabContext context)
        {
            _context = context;
        }

        public void Create(Client entity)
        {
            _context.Clients.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Client entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Client> GetAll()
        {
            return _context.Clients.AsNoTracking().Where(x => x.Active == true).OrderBy(x => x.Name);
        }

        public Client GetById(long id)
        {
            return _context.Clients.FirstOrDefault(x => x.Id == id);
        }
    }
}