using System.Collections.Generic;
using System.Threading.Tasks;
using Strab.Domain.Entities;
using Strab.Domain.Repositories;

namespace Strab.Domain.Tests.Repositories
{
    public class FakeUserRepository : IUserRepository
    {
        public void Create(User entity)
        {

        }

        public void Delete(User entity)
        {

        }

        public void Update(User entity)
        {

        }

        public async Task<IEnumerable<User>> GetAll()
        {
            Task<IEnumerable<User>> task = new Task<IEnumerable<User>>(() => new List<User>());
            task.Start();
            task.Wait();
            return task.Result;
        }

        public User GetById(long id)
        {
            return new User();
        }

        public async Task<User> Login(string email, string password)
        {
            Task<User> task = new Task<User>(() => new User());
            task.Start();
            task.Wait();
            return task.Result;
        }
    }
}