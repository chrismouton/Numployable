using AutoMapper;
using Numployable.APIClient.Client;
using Numployable.APIClient.Contracts;
using Numployable.UI.Web.Contracts;
using Numployable.UI.Web.Models;

namespace Numployable.UI.Web.Services;

public class ApplicationStatusService(IMapper mapper, IClient httpClient, ILocalStorageService localStorage)
  : BaseHttpService(httpClient, localStorage), IApplicationStatusService
{
  public async Task<List<InfrastructureDataViewModel>> GetAll()
  {
    var statusList = await _client.StatusAsync();
    return mapper.Map<List<InfrastructureDataViewModel>>(statusList);
  }
}
