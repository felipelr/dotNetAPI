using System;
using Microsoft.EntityFrameworkCore;
using Strab.Domain.Entities;
using Strab.Domain.Infra.Contexts;
using Strab.Domain.Repositories;

namespace Strab.Domain.Infra.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        private StrabContext _context;
        public RoleRepository(StrabContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await new Task<IEnumerable<Role>>(() => _context.Roles.AsNoTracking().OrderBy(x => x.Name));
        }
    }
}