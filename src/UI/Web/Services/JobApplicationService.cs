using AutoMapper;
using Numployable.APIClient;
using Numployable.APIClient.Client;
using Numployable.APIClient.Contracts;
using Numployable.UI.Web.Contracts;
using Numployable.UI.Web.Models;

namespace Numployable.UI.Web.Services;

public class JobApplicationService(IMapper mapper, IClient httpClient, ILocalStorageService localStorage)
    : BaseHttpService(httpClient, localStorage), IJobApplicationService
{
  private readonly IMapper _mapper = mapper;

  public async Task<Response<int>> Create(CreateJobApplicationViewModel jobApplication)
  {
    try
    {
      var response = new Response<int>();
      CreateJobApplicationDto jobApplicationDto = _mapper.Map<CreateJobApplicationDto>(jobApplication);
      var apiResponse = await _client.JobApplicationPOSTAsync(jobApplicationDto);
      if (apiResponse.Success)
      {
        response.Data = apiResponse.Id;
        response.Success = true;
      }
      else
      {
        response.ValidationErrors = string.Join(Environment.NewLine, apiResponse.Errors);
      }

      return response;
    }
    catch (ApiException ex)
    {
      return ConvertApiExceptions<int>(ex);
    }
  }

  public async Task<Response<int>> Expire(int id)
  {
    try
    {
      await _client.ExpireAsync(id);

      return new Response<int>
      {
        Success = true
      };
    }
    catch (ApiException ex)
    {
      return ConvertApiExceptions<int>(ex);
    }
  }

  public async Task<JobApplicationViewModel> Get(int id)
  {
    var jobApplicationDto = await _client.JobApplicationGETAsync(id);
    return _mapper.Map<JobApplicationViewModel>(jobApplicationDto);
  }

  public async Task<List<JobApplicationViewModel>> GetAll()
  {
    var jobApplicationDtos = await _client.JobApplicationAllAsync();
    return _mapper.Map<List<JobApplicationViewModel>>(jobApplicationDtos);
  }

  public async Task<Response<int>> ProcessUpdate(int id, ProcessStatus processStatus)
  {
    try
    {
      await _client.ProcessupdateAsync(id, processStatus.Id);

      return new Response<int>
      {
        Success = true
      };
    }
    catch (ApiException ex)
    {
      return ConvertApiExceptions<int>(ex);
    }
  }

  public async Task<Response<int>> Reject(int id)
  {
    try
    {
      await _client.RejectAsync(id);

      return new Response<int>
      {
        Success = true
      };
    }
    catch (ApiException ex)
    {
      return ConvertApiExceptions<int>(ex);
    }
  }

  public async Task<Response<int>> Update(int id, JobApplicationViewModel jobApplication)
  {
    try
    {
      UpdateJobApplicationDto jobApplicationDto = _mapper.Map<UpdateJobApplicationDto>(jobApplication);
      await _client.JobApplicationPUTAsync(id, jobApplicationDto);

      return new Response<int>
      {
        Success = true
      };
    }
    catch (ApiException ex)
    {
      return ConvertApiExceptions<int>(ex);
    }
  }
}
