namespace Numployable.Application.Persistence.Contracts;

public interface IInfrastructureDataRepository<T>
    where T : class
{
    Task<T> Get(int id);
    
    Task<IReadOnlyList<T>> GetAll();

    Task<bool> Exists(int id);

    T GetByDescription(string description);
}