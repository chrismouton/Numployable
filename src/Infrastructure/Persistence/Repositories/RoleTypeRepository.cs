namespace Numployable.Persistence.Repositories;

using Application.Persistence.Contracts;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;

public class RoleTypeRepository(NumployableDbContext dbContext, IMapper mapper)
    : IRoleTypeRepository
{
    public async Task<RoleType> Get(int id)
    {
        RoleType entity = await dbContext.Set<RoleType>().FindAsync(id);

        return entity;
    }

    public async Task<bool> Exists(int id)
    {
        RoleType entity = await Get(id);

        return entity != null;
    }

    public async Task<IReadOnlyList<RoleType>> GetAll()
    {
        List<RoleType> entities = await dbContext.Set<RoleType>().ToListAsync();

        List<RoleType> list = new(entities.Count);
        list.AddRange(entities.Select(mapper.Map<RoleType>));

        return list;
    }

    public RoleType GetByDescription(string description)
    {
        RoleType entity = dbContext
            .RoleType.FromSql($"SELECT \"Id\", \"Description\" FROM public.\"RoleType\"")
            .Where(e => e.Description == description)
            .FirstOrDefault();

        return entity;
    }
}
