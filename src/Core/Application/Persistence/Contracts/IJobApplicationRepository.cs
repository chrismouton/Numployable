namespace Numployable.Application.Persistence.Contracts;

using System.Collections.Generic;
using System.Threading.Tasks;
using Numployable.Domain;

public interface IJobApplicationRepository : IGenericRepository<JobApplication>
{
    Task<JobApplication> GetJobApplicationWithDetails(int id);

    Task<List<JobApplication>> GetJobApplicationsWithDetails();

    Task ExpireJobApplication(JobApplication application, Status status);

    Task ProcessUpdateJobApplication(JobApplication application, ProcessStatus processStatus);

    Task RejectedJobApplication(JobApplication application, Status status, ProcessStatus processStatus);
}