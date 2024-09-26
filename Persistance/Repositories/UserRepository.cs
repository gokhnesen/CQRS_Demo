using Application.Services.Repositories;
using Domain.Entities.User;
using Persistance.Contexts;
using Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<User,int,BaseDbContext>,IUserRepository
    {
        public UserRepository(BaseDbContext context): base(context) { }
    }
}
