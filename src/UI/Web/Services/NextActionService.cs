using AutoMapper;
using Numployable.APIClient;
using Numployable.APIClient.Client;
using Numployable.APIClient.Contracts;
using Numployable.UI.Web.Contracts;
using Numployable.UI.Web.Mappings;
using Numployable.UI.Web.Models;

namespace Numployable.UI.Web.Services;

public class NextActionService(IClient httpClient, ILocalStorageService localStorage, IMapper mapper)
    : BaseHttpService(httpClient, localStorage), INextActionService
{
    public async Task<Response<int>> Create(CreateNextActionViewModel nextAction)
    {
        try
        {
            var response = new Response<int>();
            CreateNextActionDto nextActionDto = nextAction.ToNextAction(mapper);
            var apiResponse = await _client.NextActionPOSTAsync(nextActionDto);
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

    public async Task<NextActionViewModel> Get(int id)
    {
        NextActionDto nextActionDto = await _client.NextActionGETAsync(id);
        return nextActionDto.ToNextAction(mapper);
    }

    public async Task<List<NextActionViewModel>> GetAll()
    {
        ICollection<NextActionDto> nextActions = await _client.NextActionAllAsync();
        return (from item in nextActions
               select item.ToNextAction(mapper)).ToList();
    }

    public async Task<Response<int>> Update(int id, NextActionViewModel nextAction)
    {
        try
        {
            UpdateNextActionDto nextActionDto = nextAction.ToNextAction(mapper);
            await _client.NextActionPUTAsync(id, nextActionDto);

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
