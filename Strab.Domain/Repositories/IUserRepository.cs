using Strab.Domain.Entities;

namespace Strab.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> Login(string email, string password);
    }
}