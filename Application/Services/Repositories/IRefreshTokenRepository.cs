using Application.Interfaces;
using Domain.Entities.User;

namespace Application.Services.Repositories
{
    public interface IRefreshTokenRepository : IAsyncRepository<RefreshToken, int>, IRepository<RefreshToken, int>
    {
        Task<List<RefreshToken>> GetOldRefreshTokensAsync(int userID, int refreshTokenTTL);
    }

}
