namespace Numployable.Persistence.Repositories;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

public class SourceRepository(NumployableDbContext dbContext, IMapper mapper) 
    : ISourceRepository
{
    public async Task<Source> Get(int id)
    {
        Model.Source entity = await dbContext.Set<Model.Source>().FindAsync(id);

        return entity;
    }

    public async Task<bool> Exists(int id)
    {
        Source entity = await Get(id);

        return entity != null;
    }

    public async Task<IReadOnlyList<Source>> GetAll()
    {
        List<Model.Source> entities = await dbContext.Set<Model.Source>().ToListAsync();

        List<Source> list = new(entities.Count);
        list.AddRange(entities.Select(mapper.Map<Source>));

        return list;
    }

    public Source GetByDescription(string description)
    {
        Model.Source entity = dbContext.Source
                .FromSql($"SELECT \"Id\", \"Description\" FROM public.\"Source\"")
                .Where(e => e.Description == description)
                .FirstOrDefault();

        return entity;
    }
}
