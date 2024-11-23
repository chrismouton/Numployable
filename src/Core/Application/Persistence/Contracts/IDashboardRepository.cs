using Numployable.Domain;

namespace Numployable.Application.Persistence.Contracts;

public interface IDashboardRepository
{
    Task<Dashboard> Get();
}
