namespace Numployable.Application.Persistence.Contracts;

public interface IReferenceDataRepository<T>
    where T : class
{
    Task<T> Get(int id);
    
    Task<IReadOnlyList<T>> GetAll();

    Task<bool> Exists(int id);

    Task<T> GetByDescription(string description);
}