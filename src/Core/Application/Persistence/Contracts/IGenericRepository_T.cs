namespace Numployable.Application.Persistence.Contracts;

using System.Collections.Generic;
using System.Threading.Tasks;

public interface IGenericRepository<T> where T : class
{
    Task<T> Get(int id);

    Task<IReadOnlyList<T>> GetAll();

    Task<T> Add(T entity);

    Task<T> Update(T entity);

    Task<T> Delete(T entity);

    Task<bool> Exists(int id);
}