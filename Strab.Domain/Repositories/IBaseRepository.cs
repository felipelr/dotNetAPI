using System;
using System.Collections.Generic;

namespace Strab.Domain.Repositories
{
    public interface IBaseRepository<T>
    {
        void Create(T entity);
        void Update(T entity);
        T GetById(long id);
        IEnumerable<T> GetAll();
    }
}