namespace Numployable.Persistence.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Persistence.Contracts;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;

public class NextActionRepository(NumployableDbContext dbContext, IMapper mapper)
    : INextActionRepository
{
    internal readonly NumployableDbContext _dbContext = dbContext;
    internal readonly IMapper _mapper = mapper;

    public async Task<Domain.NextAction> Add(Domain.NextAction nextAction)
    {
        NextAction entity = _mapper.Map<NextAction>(nextAction);

        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<Domain.NextAction>(entity);
    }

    public async Task<bool> Exists(int id)
    {
        Domain.NextAction entity = await Get(id);
        return entity != null;
    }

    public async Task<Domain.NextAction> Get(int id)
    {
        NextAction entity = await _dbContext.Set<NextAction>().FindAsync(id);

        return _mapper.Map<Domain.NextAction>(entity);
    }

    public async Task<IReadOnlyList<Domain.NextAction>> GetAll()
    {
        List<NextAction> entities = await _dbContext.Set<NextAction>().ToListAsync();

        List<Domain.NextAction> applications = new(entities.Count);
        applications.AddRange(entities.Select(_mapper.Map<Domain.NextAction>));

        return applications;
    }

    public async Task Update(Domain.NextAction application)
    {
        NextAction entity = _mapper.Map<NextAction>(application);
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}
