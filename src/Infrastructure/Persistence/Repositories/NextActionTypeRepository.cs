namespace Numployable.Persistence.Repositories;

using Application.Persistence.Contracts;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;

public class NextActionTypeRepository(NumployableDbContext dbContext, IMapper mapper)
    : INextActionTypeRepository
{
    public async Task<NextActionType> Get(int id)
    {
        NextActionType entity = await dbContext.Set<NextActionType>().FindAsync(id);

        return entity;
    }

    public async Task<bool> Exists(int id)
    {
        NextActionType entity = await Get(id);

        return entity != null;
    }

    public async Task<IReadOnlyList<NextActionType>> GetAll()
    {
        List<NextActionType> entities = await dbContext.Set<NextActionType>().ToListAsync();

        List<NextActionType> list = new(entities.Count);
        list.AddRange(entities.Select(mapper.Map<NextActionType>));

        return list;
    }

    public async Task<NextActionType> GetByDescription(string description)
    {
        NextActionType entity = dbContext
            .NextActionType.FromSql(
                $"SELECT \"Id\", \"Description\" FROM public.\"NextActionType\""
            )
            .Where(e => e.Description == description)
            .FirstOrDefault();

        return entity;
    }
}
