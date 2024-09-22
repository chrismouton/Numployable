namespace Numployable.Persistence.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Persistence.Contracts;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;

public class JobApplicationRepository(NumployableDbContext dbContext, IMapper mapper)
    : IJobApplicationRepository
{
    internal readonly NumployableDbContext _dbContext = dbContext;
    internal readonly IMapper _mapper = mapper;

    public async Task<Domain.JobApplication> Add(Domain.JobApplication application)
    {
        JobApplication entity = _mapper.Map<JobApplication>(application);

        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<Domain.JobApplication>(entity);
    }

    public async Task<bool> Exists(int id)
    {
        Domain.JobApplication entity = await Get(id);
        return entity != null;
    }

    public async Task<Domain.JobApplication> Get(int id)
    {
        JobApplication entity = await _dbContext.Set<JobApplication>().FindAsync(id);

        return _mapper.Map<Domain.JobApplication>(entity);
    }

    public async Task<IReadOnlyList<Domain.JobApplication>> GetAll()
    {
        List<JobApplication> entities = await _dbContext.Set<JobApplication>().ToListAsync();

        List<Domain.JobApplication> applications = new(entities.Count);
        applications.AddRange(entities.Select(_mapper.Map<Domain.JobApplication>));

        return applications;
    }

    public async Task Update(Domain.JobApplication application)
    {
        JobApplication entity = _mapper.Map<JobApplication>(application);
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Domain.JobApplication>> GetJobApplicationsWithDetails()
    {
        var entities = await _dbContext.JobApplication.Include(q => q.NextAction).ToListAsync();

        List<Domain.JobApplication> applications = new(entities.Count);
        applications.AddRange(entities.Select(_mapper.Map<Domain.JobApplication>));

        return applications;
    }

    public async Task<Domain.JobApplication> GetJobApplicationWithDetails(int id)
    {
        var entity = await _dbContext
            .JobApplication.Include(q => q.NextAction)
            .FirstOrDefaultAsync(q => q.Id == id);

        return _mapper.Map<Domain.JobApplication>(entity);
    }
}
