using Strab.Domain.Entities;

namespace Strab.Domain.Repositories
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<IEnumerable<Role>> GetAll();
    }
}