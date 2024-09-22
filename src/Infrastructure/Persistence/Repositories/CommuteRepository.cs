namespace Numployable.Persistence.Repositories;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

public class CommuteRepository(NumployableDbContext dbContext, IMapper mapper) 
    : ICommuteRepository
{
    public async Task<Commute> Get(int id)
    {
        Model.Commute entity = await dbContext.Commute.FindAsync(id);

        return entity;
    }

    public async Task<bool> Exists(int id)
    {
        Commute entity = await Get(id);

        return entity != null;
    }

    public async Task<IReadOnlyList<Commute>> GetAll()
    {
        List<Model.Commute> entities = await dbContext.Commute.ToListAsync();

        List<Commute> list = new(entities.Count);
        list.AddRange(entities.Select(mapper.Map<Commute>));

        return list;
    }

    public Commute GetByDescription(string description)
    {
        Model.Commute entity = dbContext.Commute
                .FromSql($"SELECT \"Id\", \"Description\" FROM public.\"Commute\"")
                .Where(e => e.Description == description)
                .FirstOrDefault();

        return entity;
    }
}
