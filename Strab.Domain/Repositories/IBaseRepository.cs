using System;
using System.Collections.Generic;

namespace Strab.Domain.Repositories
{
    public interface IBaseRepository<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> GetById(long id);
    }
}