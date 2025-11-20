using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Persistence.Repositories;

public class NextActionRepository(NumployableDbContext dbContext, IMapper mapper)
    : INextActionRepository
{
    public async Task<NextAction> Add(NextAction nextAction)
    {
        NextAction? entity = mapper.Map<NextAction>(nextAction);

        await dbContext.AddAsync(entity);
        await dbContext.SaveChangesAsync();

        return mapper.Map<NextAction>(entity);
    }

    public async Task<bool> Exists(int id)
    {
        NextAction? entity = await Get(id);
        return entity != null;
    }

    public async Task<NextAction> Get(int id)
    {
        NextAction? entity = await dbContext.Set<NextAction>().FindAsync(id);

        return mapper.Map<NextAction>(entity);
    }

    public async Task<IReadOnlyList<NextAction>> GetAll()
    {
        List<NextAction> entities = await dbContext.Set<NextAction>().ToListAsync();

        List<NextAction> applications = new(entities.Count);
        applications.AddRange(entities.Select(mapper.Map<NextAction>));

        return applications;
    }

    public async Task Update(NextAction application)
    {
        NextAction? entity = mapper.Map<NextAction>(application);
        dbContext.Entry(entity).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();
    }
}