using System;
using System.Collections.Generic;

namespace Strab.Domain.Repositories
{
    public interface IBaseRepository<T>
    {
        void Save(T entity);
        T GetById(long id);
        IEnumerable<T> GetAll();
    }
}