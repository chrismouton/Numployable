namespace Numployable.Persistence.Repositories;

using AutoMapper;
using Microsoft.EntityFrameworkCore;

using Application.Persistence.Contracts;
using Domain;

public class ProcessStatusRepository(NumployableDbContext dbContext, IMapper mapper) 
    : IProcessStatusRepository
{
    public async Task<ProcessStatus> Get(int id)
    {
        ProcessStatus entity = await dbContext.Set<ProcessStatus>().FindAsync(id);

        return entity;
    }

    public async Task<bool> Exists(int id)
    {
        ProcessStatus entity = await Get(id);

        return entity != null;
    }

    public async Task<IReadOnlyList<ProcessStatus>> GetAll()
    {
        List<ProcessStatus> entities = await dbContext.Set<ProcessStatus>().ToListAsync();

        List<ProcessStatus> list = new(entities.Count);
        list.AddRange(entities.Select(mapper.Map<ProcessStatus>));

        return list;
    }

    public ProcessStatus GetByDescription(string description)
    {
        ProcessStatus entity = dbContext.ProcessStatus
                .FromSql($"SELECT \"Id\", \"Description\" FROM public.\"ProcessStatus\"")
                .Where(e => e.Description == description)
                .FirstOrDefault();

        return entity;
    }
}
