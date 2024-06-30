namespace Numployable.Persistence.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

using Numployable;
using Numployable.Application.Persistence.Contracts;

public class JobApplicationRepository(NumployableDbContext dbContext, IMapper mapper)
    : IJobApplicationRepository
{
    internal readonly NumployableDbContext _dbContext = dbContext;
    internal readonly IMapper _mapper = mapper;

    public async Task<Domain.JobApplication> Add(Domain.JobApplication application)
    {
        Model.JobApplication entity = _mapper.Map<Model.JobApplication>(application);

        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<Domain.JobApplication>(entity);
    }

    public async Task<bool> Exists(int id)
    {
        Domain.JobApplication entity = await Get(id);
        return (entity != null);
    }

    public async Task<Domain.JobApplication> Get(int id)
    {
        Model.JobApplication entity = await _dbContext.Set<Model.JobApplication>().FindAsync(id);

        return _mapper.Map<Domain.JobApplication>(entity);
    }

    public async Task<IReadOnlyList<Domain.JobApplication>> GetAll()
    {
        List<Model.JobApplication> entities = await _dbContext.Set<Model.JobApplication>().ToListAsync();

        List<Domain.JobApplication> applications = new(entities.Count);
        applications.AddRange(entities.Select(_mapper.Map<Domain.JobApplication>));
        
        return applications;
    }

    public async Task Update(Domain.JobApplication application)
    {
        Model.JobApplication entity = _mapper.Map<Model.JobApplication>(application);
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }


    public async Task ExpireJobApplication(Domain.JobApplication application, Status status)
    {
        Model.JobApplication entity = await _dbContext.Set<Model.JobApplication>().FindAsync(application.Id);
        entity.StatusId = status;
        _dbContext.Entry(entity).State = EntityState.Modified;

        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Domain.JobApplication>> GetJobApplicationsWithDetails()
    {
        var entities = await _dbContext.JobApplication
            .Include(q => q.NextAction)
            .ToListAsync();

        List<Domain.JobApplication> applications = new(entities.Count);
        applications.AddRange(entities.Select(_mapper.Map<Domain.JobApplication>));

        return applications;
    }

    public async Task<Domain.JobApplication> GetJobApplicationWithDetails(int id)
    {
        var entity = await _dbContext.JobApplication
            .Include(q => q.NextAction)
            .FirstOrDefaultAsync(q => q.Id == id);

        return _mapper.Map<Domain.JobApplication>(entity);
    }

    public async Task ProcessUpdateJobApplication(Domain.JobApplication application, ProcessStatus processStatus)
    {
        Model.JobApplication entity = await _dbContext.Set<Model.JobApplication>().FindAsync(application.Id);
        entity.ProcessStatusId = processStatus;
        _dbContext.Entry(entity).State = EntityState.Modified;

        await _dbContext.SaveChangesAsync();
    }

    public async Task RejectedJobApplication(Domain.JobApplication application, Status status, ProcessStatus processStatus)
    {
        Model.JobApplication entity = await _dbContext.Set<Model.JobApplication>().FindAsync(application.Id);
        entity.StatusId = status;
        entity.ProcessStatusId = processStatus;
        _dbContext.Entry(entity).State = EntityState.Modified;

        await _dbContext.SaveChangesAsync();
    }
}