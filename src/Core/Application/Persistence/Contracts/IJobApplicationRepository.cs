namespace Numploy.Application.Persistence.Contracts;

using System.Collections.Generic;
using System.Threading.Tasks;
using Numploy.Domain;

public interface IJobApplicationRepository : IGenericRepository<JobApplication>
{
    Task<JobApplication> GetJobApplicationWithDetails(int Id);

    Task<List<JobApplication>> GetJobApplicationsWithDetails();

    Task ExpireJobApplication(JobApplication application, ApplicationStatus status);

    Task ProcessUpdateJobApplication(JobApplication application, ApplicationProcessStatus processStatus);

    Task RejectedJobApplication(JobApplication application, ApplicationStatus status, ApplicationProcessStatus processStatus);
}