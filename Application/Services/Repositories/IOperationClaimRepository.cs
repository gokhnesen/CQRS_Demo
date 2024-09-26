using Application.Interfaces;
using Domain.Entities.User;

namespace Application.Services.Repositories
{
    public interface IOperationClaimRepository : IAsyncRepository<OperationClaim, int>, IRepository<OperationClaim, int> { }

}
