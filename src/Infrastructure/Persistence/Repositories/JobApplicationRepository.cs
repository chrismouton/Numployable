using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Persistence.Repositories;

public class JobApplicationRepository(NumployableDbContext dbContext, IMapper mapper)
    : IJobApplicationRepository
{
    internal readonly NumployableDbContext _dbContext = dbContext;
    internal readonly IMapper _mapper = mapper;

    public async Task<JobApplication> Add(JobApplication application)
    {
        JobApplication entity = _mapper.Map<JobApplication>(application);

        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<JobApplication>(entity);
    }

    public async Task<bool> Exists(int id)
    {
        JobApplication entity = await Get(id);
        return entity != null;
    }

    public async Task<JobApplication> Get(int id)
    {
        JobApplication entity = await _dbContext.Set<JobApplication>().FindAsync(id);

        return _mapper.Map<JobApplication>(entity);
    }

    public async Task<IReadOnlyList<JobApplication>> GetAll()
    {
        List<JobApplication> entities = await _dbContext.JobApplication
            .Include(q => q.Status)
            .Include(q => q.ProcessStatus)
            .Include(q => q.RoleType).ToListAsync();

        List<JobApplication> applications = new(entities.Count);
        applications.AddRange(entities.Select(_mapper.Map<JobApplication>));

        return applications;
    }

    public async Task Update(JobApplication application)
    {
        JobApplication entity = _mapper.Map<JobApplication>(application);
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<JobApplication>> GetJobApplicationsWithDetails()
    {
        var entities = await _dbContext.JobApplication.Include(q => q.NextAction).ToListAsync();

        List<JobApplication> applications = new(entities.Count);
        applications.AddRange(entities.Select(_mapper.Map<JobApplication>));

        return applications;
    }

    public async Task<JobApplication> GetJobApplicationWithDetails(int id)
    {
        var entity = await _dbContext
            .JobApplication.Include(q => q.NextAction)
            .FirstOrDefaultAsync(q => q.Id == id);

        return _mapper.Map<JobApplication>(entity);
    }
}
