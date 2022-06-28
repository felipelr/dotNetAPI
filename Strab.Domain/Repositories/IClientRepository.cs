using Strab.Domain.Entities;

namespace Strab.Domain.Repositories
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        Task<IEnumerable<Client>> GetAll();
        Task<Client> GetByUserId(long userId);
    }
}