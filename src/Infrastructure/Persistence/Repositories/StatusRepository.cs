namespace Numployable.Persistence.Repositories;

using Application.Persistence.Contracts;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;

public class StatusRepository(NumployableDbContext dbContext, IMapper mapper) : IStatusRepository
{
    public async Task<Status> Get(int id)
    {
        Status entity = await dbContext.Set<Status>().FindAsync(id);

        return entity;
    }

    public async Task<bool> Exists(int id)
    {
        Status entity = await Get(id);

        return entity != null;
    }

    public async Task<IReadOnlyList<Status>> GetAll()
    {
        List<Status> entities = await dbContext.Set<Status>().ToListAsync();

        List<Status> list = new(entities.Count);
        list.AddRange(entities.Select(mapper.Map<Status>));

        return list;
    }

    public Status GetByDescription(string description)
    {
        Status entity = dbContext
            .Status.FromSql($"SELECT \"Id\", \"Description\" FROM public.\"Status\"")
            .Where(e => e.Description == description)
            .FirstOrDefault();

        return entity;
    }
}
