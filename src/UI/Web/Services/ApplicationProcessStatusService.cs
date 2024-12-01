using AutoMapper;
using Numployable.APIClient.Client;
using Numployable.APIClient.Contracts;
using Numployable.UI.Web.Contracts;
using Numployable.UI.Web.Models;

namespace Numployable.UI.Web.Services;

public class ApplicationProcessStatusService(IMapper mapper, IClient httpClient, ILocalStorageService localStorage)
  : BaseHttpService(httpClient, localStorage), IApplicationProcessStatusService
{
  public async Task<List<InfrastructureDataViewModel>> GetAll()
  {
    var processStatusList = await _client.ProcessStatusAsync();
    return mapper.Map<List<InfrastructureDataViewModel>>(processStatusList);
  }
}
