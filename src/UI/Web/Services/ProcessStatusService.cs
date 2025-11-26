using AutoMapper;
using Numployable.APIClient.Client;
using Numployable.APIClient.Contracts;
using Numployable.UI.Web.Contracts;
using Numployable.UI.Web.Models;

namespace Numployable.UI.Web.Services;

public class ProcessStatusService(IMapper mapper, IClient httpClient, ILocalStorageService localStorage)
  : BaseHttpService(httpClient, localStorage), IProcessStatusService
{
  public async Task<List<ReferenceDataViewModel>> GetAll()
  {
    ICollection<ProcessStatusDto>? processStatusList = await httpClient.ProcessstatusAllAsync();
    return mapper.Map<List<ReferenceDataViewModel>>(processStatusList);
  }
}
