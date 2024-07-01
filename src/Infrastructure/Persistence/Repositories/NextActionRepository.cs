namespace Numployable.Persistence.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.EntityFrameworkCore;

using Numployable;
using Numployable.Application.Persistence.Contracts;

public class NextActionRepository(NumployableDbContext dbContext, IMapper mapper)
    : INextActionRepository
{
    internal readonly NumployableDbContext _dbContext = dbContext;
    internal readonly IMapper _mapper = mapper;

    public async Task<Domain.NextAction> Add(Domain.NextAction nextAction)
    {
        Model.NextAction entity = _mapper.Map<Model.NextAction>(nextAction);

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
        Model.NextAction entity = await _dbContext.Set<Model.NextAction>().FindAsync(id);

        return _mapper.Map<Domain.NextAction>(entity);
    }

    public async Task<IReadOnlyList<Domain.NextAction>> GetAll()
    {
        List<Model.NextAction> entities = await _dbContext.Set<Model.NextAction>().ToListAsync();

        List<Domain.NextAction> applications = new(entities.Count);
        applications.AddRange(entities.Select(_mapper.Map<Domain.NextAction>));
        
        return applications;
    }

        public async Task Update(Domain.NextAction application)
    {
        Model.NextAction entity = _mapper.Map<Model.NextAction>(application);
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
}