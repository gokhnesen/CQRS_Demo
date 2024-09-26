using Application.Interfaces;
using Domain.Entities.User;

namespace Application.Services.Repositories
{
    public interface IEmailAuthenticatorRepository : IAsyncRepository<EmailAuthenticator, int>, IRepository<EmailAuthenticator, int> { }

}
