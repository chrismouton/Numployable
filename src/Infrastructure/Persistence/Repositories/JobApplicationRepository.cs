using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Persistence.Repositories;

public class JobApplicationRepository(NumployableDbContext dbContext, IMapper mapper)
    : IJobApplicationRepository
{
    public async Task<JobApplication> Add(JobApplication application)
    {
        JobApplication? entity = mapper.Map<JobApplication>(application);

        await dbContext.AddAsync(entity);
        await dbContext.SaveChangesAsync();

        return mapper.Map<JobApplication>(entity);
    }

    public async Task<bool> Exists(int id)
    {
        JobApplication? entity = await Get(id);
        return entity != null;
    }

    public async Task<JobApplication> Get(int id)
    {
        JobApplication? entity = await dbContext.Set<JobApplication>().FindAsync(id);

        return mapper.Map<JobApplication>(entity);
    }

    public async Task<IReadOnlyList<JobApplication>> GetAll()
    {
        List<JobApplication> entities = await dbContext.JobApplication
            .Include(q => q.Status)
            .Include(q => q.ProcessStatus)
            .Include(q => q.RoleType).ToListAsync();

        List<JobApplication> applications = new(entities.Count);
        applications.AddRange(entities.Select(mapper.Map<JobApplication>));

        return applications;
    }

    public async Task Update(JobApplication application)
    {
        JobApplication? entity = mapper.Map<JobApplication>(application);
        dbContext.Entry(entity).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();
    }

    public async Task<List<JobApplication>> GetJobApplicationsWithDetails()
    {
        List<JobApplication>? entities = await dbContext.JobApplication.Include(q => q.NextAction).ToListAsync();

        List<JobApplication> applications = new(entities.Count);
        applications.AddRange(entities.Select(mapper.Map<JobApplication>));

        return applications;
    }

    public async Task<JobApplication> GetJobApplicationWithDetails(int id)
    {
        JobApplication? entity = await dbContext
            .JobApplication.Include(q => q.NextAction)
            .FirstOrDefaultAsync(q => q.Id == id);

        return mapper.Map<JobApplication>(entity);
    }
}