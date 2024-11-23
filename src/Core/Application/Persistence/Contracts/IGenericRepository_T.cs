namespace Numployable.Application.Persistence.Contracts;

public interface IGenericRepository<T> where T : class
{
    Task<T> Get(int id);

    Task<IReadOnlyList<T>> GetAll();

    Task<T> Add(T domainEntity);

    Task Update(T domainEntity);

    Task<bool> Exists(int id);
}