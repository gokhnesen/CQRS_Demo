using Application.Interfaces;
using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories
{
    public interface IUserRepository : IAsyncRepository<User, int>, IRepository<User, int> { }

}
