using System;
using Microsoft.EntityFrameworkCore;
using Strab.Domain.Entities;
using Strab.Domain.Infra.Contexts;
using Strab.Domain.Repositories;

namespace Strab.Domain.Infra.Repositories
{
    public class ProfessionalRepository : IProfessionalRepository
    {
        private readonly StrabContext _context;

        public ProfessionalRepository(StrabContext context)
        {
            _context = context;
        }

        public void Create(Professional entity)
        {
            _context.Professionals.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Professional entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Professional entity)
        {
            _context.Professionals.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Professional> GetAll()
        {
            return _context.Professionals.AsNoTracking().Where(x => x.Active == true).OrderBy(x => x.Name);
        }

        public Professional GetById(long id)
        {
            return _context.Professionals.FirstOrDefault(x => x.Id == id);
        }
    }
}