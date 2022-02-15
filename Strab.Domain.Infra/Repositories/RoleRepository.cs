using System;
using Microsoft.EntityFrameworkCore;
using Strab.Domain.Entities;
using Strab.Domain.Infra.Contexts;
using Strab.Domain.Repositories;

namespace Strab.Domain.Infra.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly StrabContext _context;

        public RoleRepository(StrabContext context)
        {
            _context = context;
        }

        public void Create(Role entity)
        {
            _context.Roles.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Role entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Role entity)
        {
            _context.Roles.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await new Task<IEnumerable<Role>>(() => _context.Roles.AsNoTracking().OrderBy(x => x.Name));
        }

        public Role GetById(long id)
        {
            return _context.Roles.FirstOrDefault(x => x.Id == id);
        }
    }
}