namespace Numployable.Application.Persistence.Contracts;

using System.Collections.Generic;
using System.Threading.Tasks;
using Numployable.Domain;

public interface IJobApplicationRepository : IGenericRepository<JobApplication>
{
    Task<JobApplication> GetJobApplicationWithDetails(int id);

    Task<List<JobApplication>> GetJobApplicationsWithDetails();

    Task ExpireJobApplication(JobApplication application, ApplicationStatus status);

    Task ProcessUpdateJobApplication(JobApplication application, ApplicationProcessStatus processStatus);

    Task RejectedJobApplication(JobApplication application, ApplicationStatus status, ApplicationProcessStatus processStatus);
}