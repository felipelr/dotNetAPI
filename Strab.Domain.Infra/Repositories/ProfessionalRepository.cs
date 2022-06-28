using System;
using Microsoft.EntityFrameworkCore;
using Strab.Domain.Entities;
using Strab.Domain.Infra.Contexts;
using Strab.Domain.Repositories;

namespace Strab.Domain.Infra.Repositories
{
    public class ProfessionalRepository : BaseRepository<Professional>, IProfessionalRepository
    {
        private StrabContext _context;
        public ProfessionalRepository(StrabContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Professional>> GetAll()
        {
            return await new Task<IEnumerable<Professional>>(() => _context.Professionals.AsNoTracking().Where(x => x.Active == true).OrderBy(x => x.Name));
        }

        public async Task<Professional> GetByUserId(long userId)
        {
            return await _context.Professionals.FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}