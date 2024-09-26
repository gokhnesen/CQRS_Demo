using Application.Interfaces;
using Domain.Entities.User;

namespace Application.Services.Repositories
{
    public interface IOtpAuthenticatorRepository : IAsyncRepository<OtpAuthenticator, int>, IRepository<OtpAuthenticator, int> { }

}
