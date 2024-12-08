using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Persistence.Repositories;

public class SourceRepository(NumployableDbContext dbContext, IMapper mapper)
    : ISourceRepository
{
    public async Task<Source> Get(int id)
    {
        Source? entity = await dbContext.Set<Source>().FindAsync(id);

        return entity;
    }

    public async Task<bool> Exists(int id)
    {
        Source? entity = await Get(id);

        return entity != null;
    }

    public async Task<IReadOnlyList<Source>> GetAll()
    {
        List<Source> entities = await dbContext.Set<Source>().ToListAsync();

        List<Source> list = new(entities.Count);
        list.AddRange(entities.Select(mapper.Map<Source>));

        return list;
    }

    public async Task<Source> GetByDescription(string description)
    {
        Source? entity = dbContext.Source
            .FromSql($"SELECT \"Id\", \"Description\" FROM public.\"Source\"")
            .Where(e => e.Description == description)
            .FirstOrDefault();

        return entity;
    }
}