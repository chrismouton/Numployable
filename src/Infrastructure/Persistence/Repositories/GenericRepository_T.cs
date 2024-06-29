namespace Numployable.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using Numployable.Application.Persistence.Contracts;

public class GenericRepository<T>(NumployableDbContext dbContext) : IGenericRepository<T> where T : class
{
    internal readonly NumployableDbContext _dbContext = dbContext;

    public async Task<T> Add(T entity)
    {
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> Exists(int id)
    {
        T entity = await Get(id);
        return (entity != null);
    }

    public async Task<T> Get(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> GetAll()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task Update(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}