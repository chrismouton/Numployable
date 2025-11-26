using AutoMapper;
using Numployable.APIClient;
using Numployable.APIClient.Client;
using Numployable.APIClient.Contracts;
using Numployable.UI.Web.Contracts;
using Numployable.UI.Web.Mappings;
using Numployable.UI.Web.Models;

namespace Numployable.UI.Web.Services;

public class JobApplicationService(IClient httpClient, ILocalStorageService localStorage, IMapper mapper)
  : BaseHttpService(httpClient, localStorage), IJobApplicationService
{
  public async Task<Response<int>> Create(CreateJobApplicationViewModel jobApplication)
  {
    try
    {
      Response<int>? response = new();
      CreateJobApplicationDto? jobApplicationDto = jobApplication.ToJobApplication();
      BaseCommandResponse? apiResponse = await httpClient.JobApplicationPOSTAsync(jobApplicationDto);
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
      await httpClient.ExpireAsync(id);

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
    JobApplicationDto? jobApplicationDto = await httpClient.JobApplicationGETAsync(id);
    return jobApplicationDto.ToJobApplication(mapper);
  }

  public async Task<List<JobApplicationViewModel>> GetAll()
  {
    ICollection<JobApplicationListDto> jobApplicationDtos = await httpClient.JobApplicationAllAsync();
    return (from item in jobApplicationDtos
      select item.ToJobApplication(mapper)).ToList();
  }

  public async Task<Response<int>> ProcessUpdate(int id, ProcessStatus processStatus)
  {
    try
    {
      await httpClient.ProcessupdateAsync(id, processStatus.Id);

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
      await httpClient.RejectAsync(id);

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
      UpdateJobApplicationDto? jobApplicationDto = jobApplication.ToJobApplication(mapper);
      await httpClient.JobApplicationPUTAsync(id, jobApplicationDto);

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
