namespace Numployable.Persistence.Repositories;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

public class StatusRepository(NumployableDbContext dbContext, IMapper mapper) 
    : IStatusRepository
{
    public async Task<Status> Get(int id)
    {
        Model.Status entity = await dbContext.Set<Model.Status>().FindAsync(id);

        return entity;
    }

    public async Task<bool> Exists(int id)
    {
        Status entity = await Get(id);

        return entity != null;
    }

    public async Task<IReadOnlyList<Status>> GetAll()
    {
        List<Model.Status> entities = await dbContext.Set<Model.Status>().ToListAsync();

        List<Status> list = new(entities.Count);
        list.AddRange(entities.Select(mapper.Map<Status>));

        return list;
    }

    public Status GetByDescription(string description)
    {
        Model.Status entity = dbContext.Status
                .FromSql($"SELECT \"Id\", \"Description\" FROM public.\"Status\"")
                .Where(e => e.Description == description)
                .FirstOrDefault();

        return entity;
    }
}
