using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Persistence.Repositories;

public class NextActionRepository(NumployableDbContext dbContext, IMapper mapper)
    : INextActionRepository
{
    internal readonly NumployableDbContext _dbContext = dbContext;
    internal readonly IMapper _mapper = mapper;

    public async Task<NextAction> Add(NextAction nextAction)
    {
        NextAction entity = _mapper.Map<NextAction>(nextAction);

        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<NextAction>(entity);
    }

    public async Task<bool> Exists(int id)
    {
        NextAction entity = await Get(id);
        return entity != null;
    }

    public async Task<NextAction> Get(int id)
    {
        NextAction entity = await _dbContext.Set<NextAction>().FindAsync(id);

        return _mapper.Map<NextAction>(entity);
    }

    public async Task<IReadOnlyList<NextAction>> GetAll()
    {
        List<NextAction> entities = await _dbContext.Set<NextAction>().ToListAsync();

        List<NextAction> applications = new(entities.Count);
        applications.AddRange(entities.Select(_mapper.Map<NextAction>));

        return applications;
    }

    public async Task Update(NextAction application)
    {
        NextAction entity = _mapper.Map<NextAction>(application);
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}
