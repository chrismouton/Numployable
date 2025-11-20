using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Persistence.Repositories;

public class RoleTypeRepository(NumployableDbContext dbContext, IMapper mapper)
    : IRoleTypeRepository
{
    public async Task<RoleType?> Get(int id)
    {
        RoleType? entity = await dbContext.Set<RoleType>().FindAsync(id);

        return entity;
    }

    public async Task<bool> Exists(int id)
    {
        RoleType? entity = await Get(id);

        return entity != null;
    }

    public async Task<IReadOnlyList<RoleType>> GetAll()
    {
        List<RoleType> entities = await dbContext.Set<RoleType>().ToListAsync();

        List<RoleType> list = new(entities.Count);
        list.AddRange(entities.Select(mapper.Map<RoleType>));

        return list;
    }

    public Task<RoleType?> GetByDescription(string description)
    {
        RoleType? entity = dbContext
            .RoleType.FromSql($"SELECT \"Id\", \"Description\" FROM public.\"RoleType\"")
            .Where(e => e.Description == description)
            .FirstOrDefault();

        return Task.FromResult(entity);
    }
}