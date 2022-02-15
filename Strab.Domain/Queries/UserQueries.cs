using System.Linq.Expressions;
using Strab.Domain.Entities;

namespace Strab.Domain.Queries
{
    public static class UserQueries
    {
        public static Expression<Func<User, bool>> GetByRole(int role)
        {
            return x => x.RoleId == role;
        }
        public static Expression<Func<User, bool>> GetAllActive()
        {
            return x => x.Active == true;
        }
    }
}