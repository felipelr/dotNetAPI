using System;
using Microsoft.EntityFrameworkCore;
using Strab.Domain.Entities;
using Strab.Domain.Infra.Contexts;
using Strab.Domain.Repositories;

namespace Strab.Domain.Infra.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        StrabContext _context;
        public ClientRepository(StrabContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await new Task<IEnumerable<Client>>(() => _context.Clients.AsNoTracking().Where(x => x.Active == true).OrderBy(x => x.Name));
        }

        public async Task<Client> GetByUserId(long userId)
        {
            return await _context.Clients.FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}