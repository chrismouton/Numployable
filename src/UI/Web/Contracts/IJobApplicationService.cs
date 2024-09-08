namespace Numployable.UI.Web.Contracts;

using Numployable.UI.Web.Models;
using Numployable.UI.Web.Services.Base;

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
