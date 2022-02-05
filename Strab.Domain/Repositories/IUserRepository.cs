using System;
using System.Collections.Generic;
using Strab.Domain.Entities;

namespace Strab.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public User Login(string email, string password);
    }
}