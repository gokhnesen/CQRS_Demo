﻿using Application.Interfaces;
using Domain.Entities.User;

namespace Application.Services.Repositories
{
    public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaim, int>, IRepository<UserOperationClaim, int>
    {
        Task<IList<OperationClaim>> GetOperationClaimsByUserIdAsync(int userId);
    }

}
