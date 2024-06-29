namespace Numployable.Persistence.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Numployable;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

public class JobApplicationRepository(NumployableDbContext dbContext)
    : GenericRepository<JobApplication>(dbContext), IJobApplicationRepository
{
    public async Task ExpireJobApplication(JobApplication application, ApplicationStatus status)
    {
        application.ApplicationStatus = status;
        _dbContext.Entry(application).State = EntityState.Modified;

        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<JobApplication>> GetJobApplicationsWithDetails()
    {
        var jobApplications = await _dbContext.JobApplications
            .Include(q => q.NextActions)
            .ToListAsync();

        return jobApplications;
    }

    public async Task<JobApplication> GetJobApplicationWithDetails(int id)
    {
        var jobApplication = await _dbContext.JobApplications
            .Include(q => q.NextActions)
            .FirstOrDefaultAsync(q => q.Id == id);

        return jobApplication;
    }

    public async Task ProcessUpdateJobApplication(JobApplication application, ApplicationProcessStatus processStatus)
    {
        application.ApplicationProcessStatus = processStatus;
        _dbContext.Entry(application).State = EntityState.Modified;

        await _dbContext.SaveChangesAsync();
    }

    public async Task RejectedJobApplication(JobApplication application, ApplicationStatus status, ApplicationProcessStatus processStatus)
    {
        application.ApplicationStatus = status;
        application.ApplicationProcessStatus = processStatus;
        _dbContext.Entry(application).State = EntityState.Modified;

        await _dbContext.SaveChangesAsync();
    }
}