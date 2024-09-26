using Application.Services.Repositories;
using Domain.Entities.User;
using Persistance.Contexts;
using Persistance.Repositories;

namespace Persistence.Repositories
{
    public class OtpAuthenticatorRepository : EfRepositoryBase<OtpAuthenticator, int, BaseDbContext>, IOtpAuthenticatorRepository
    {
        public OtpAuthenticatorRepository(BaseDbContext context)
            : base(context) { }
    }
}
