using Application.Services.Repositories;
using Domain.Entities.User;
using Persistance.Contexts;
using Persistance.Repositories;

namespace Persistence.Repositories
{
    public class EmailAuthenticatorRepository : EfRepositoryBase<EmailAuthenticator, int, BaseDbContext>, IEmailAuthenticatorRepository
    {
        public EmailAuthenticatorRepository(BaseDbContext context)
            : base(context) { }
    }
}
