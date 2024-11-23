using AutoMapper;
using Numployable.APIClient;
using Numployable.APIClient.Client;
using Numployable.APIClient.Contracts;
using Numployable.UI.Web.Contracts;
using Numployable.UI.Web.Models;

namespace Numployable.UI.Web.Services;

public class NextActionService(IMapper mapper, IClient httpClient, ILocalStorageService localStorage)
    : BaseHttpService(httpClient, localStorage), INextActionService
{
    private readonly IMapper _mapper = mapper;

    public async Task<Response<int>> Create(CreateNextActionViewModel nextAction)
    {
        try
        {
            var response = new Response<int>();
            CreateNextActionDto nextActionDto = _mapper.Map<CreateNextActionDto>(nextAction);
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
        var nextActionDto = await _client.NextActionGETAsync(id);
        return _mapper.Map<NextActionViewModel>(nextActionDto);
    }

    public async Task<List<NextActionViewModel>> GetAll()
    {
        var nextActions = await _client.NextActionAllAsync();
        return _mapper.Map<List<NextActionViewModel>>(nextActions);
    }

    public async Task<Response<int>> Update(int id, NextActionViewModel nextAction)
    {
        try
        {
            UpdateNextActionDto nextActionDto = _mapper.Map<UpdateNextActionDto>(nextAction);
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
