using Strab.Domain.Entities;

namespace Strab.Domain.Repositories
{
    public interface IProfessionalRepository : IBaseRepository<Professional>
    {
        Task<IEnumerable<Professional>> GetAll();
        Task<Professional> GetByUserId(long userId);
    }
}