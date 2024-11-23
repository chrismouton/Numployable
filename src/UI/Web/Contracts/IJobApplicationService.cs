using Numployable.APIClient;
using Numployable.APIClient.Client;
using Numployable.UI.Web.Models;

namespace Numployable.UI.Web.Contracts;

public interface IJobApplicationService
{
    Task<List<JobApplicationViewModel>> GetAll();

    Task<JobApplicationViewModel> Get(int id);

    Task<Response<int>> Create(CreateJobApplicationViewModel jobApplication);

    Task<Response<int>> Update(int id, JobApplicationViewModel jobApplication);

    Task<Response<int>> Expire(int id);

    Task<Response<int>> ProcessUpdate(int id, ProcessStatus processStatus);

    Task<Response<int>> Reject(int id);


}
