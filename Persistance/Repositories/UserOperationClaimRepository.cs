using Application.Services.Repositories;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;
using Persistance.Repositories;

namespace Persistence.Repositories
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, int, BaseDbContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(BaseDbContext context)
            : base(context) { }

        public async Task<IList<OperationClaim>> GetOperationClaimsByUserIdAsync(int userId)
        {
            var operationClaims = await Query()
                .AsNoTracking()
                .Where(p => p.UserId == userId)
                .Select(p => new OperationClaim { Id = p.OperationClaimId, Name = p.OperationClaim.Name })
                .ToListAsync();
            return operationClaims;
        }
    }
}
