using Numployable.Domain;

namespace Numployable.Application.Persistence.Contracts;

public interface IJobApplicationRepository : IGenericRepository<JobApplication>
{
    Task<JobApplication> GetJobApplicationWithDetails(int id);

    Task<List<JobApplication>> GetJobApplicationsWithDetails();
}