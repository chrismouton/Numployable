namespace Numployable.Application.Persistence.Contracts;

using Numployable.Domain;

public interface IDashboardRepository
{
    Task<Dashboard> Get();
}
