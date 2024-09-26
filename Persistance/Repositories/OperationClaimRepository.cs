using Application.Services.Repositories;
using Domain.Entities.User;
using Persistance.Contexts;
using Persistance.Repositories;

namespace Persistence.Repositories
{
    public class OperationClaimRepository : EfRepositoryBase<OperationClaim, int, BaseDbContext>, IOperationClaimRepository
    {
        public OperationClaimRepository(BaseDbContext context)
            : base(context) { }
    }
}
