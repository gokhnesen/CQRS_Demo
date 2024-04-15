using Application.Interfaces;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface ITransmission : IAsyncRepository<Transmission, Guid>, IRepository<Transmission, Guid>
    {

    }
}
