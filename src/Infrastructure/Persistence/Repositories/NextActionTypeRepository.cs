namespace Numployable.Persistence.Repositories;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

public class NextActionTypeRepository(NumployableDbContext dbContext, IMapper mapper) 
    : INextActionTypeRepository
{
    public async Task<NextActionType> Get(int id)
    {
        Model.NextActionType entity = await dbContext.Set<Model.NextActionType>().FindAsync(id);

        return entity;
    }

    public async Task<bool> Exists(int id)
    {
        NextActionType entity = await Get(id);

        return entity != null;
    }

    public async Task<IReadOnlyList<NextActionType>> GetAll()
    {
        List<Model.NextActionType> entities = await dbContext.Set<Model.NextActionType>().ToListAsync();

        List<NextActionType> list = new(entities.Count);
        list.AddRange(entities.Select(mapper.Map<NextActionType>));

        return list;
    }

    public NextActionType GetByDescription(string description)
    {
        Model.NextActionType entity = dbContext.NextActionType
                .FromSql($"SELECT \"Id\", \"Description\" FROM public.\"NextActionType\"")
                .Where(e => e.Description == description)
                .FirstOrDefault();

        return entity;
    }
}
