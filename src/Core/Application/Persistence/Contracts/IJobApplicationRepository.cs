namespace Numployable.Application.Persistence.Contracts;

using System.Collections.Generic;
using System.Threading.Tasks;

using Domain;

public interface IJobApplicationRepository : IGenericRepository<JobApplication>
{
    Task<JobApplication> GetJobApplicationWithDetails(int id);

    Task<List<JobApplication>> GetJobApplicationsWithDetails();
}