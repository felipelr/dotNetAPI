using System;
using Microsoft.EntityFrameworkCore;
using Strab.Domain.Infra.Contexts;
using Strab.Domain.Repositories;

namespace Strab.Domain.Infra.Repositories;
public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly StrabContext _context;

    public BaseRepository(StrabContext context)
    {
        _context = context;
    }

    public void Create(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }

    public async Task<T> GetById(long id)
    {
        return await _context.Set<T>().FindAsync(id);
    }
}