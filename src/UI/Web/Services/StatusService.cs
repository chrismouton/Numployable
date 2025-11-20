using AutoMapper;
using Numployable.APIClient.Client;
using Numployable.APIClient.Contracts;
using Numployable.UI.Web.Contracts;
using Numployable.UI.Web.Models;

namespace Numployable.UI.Web.Services;

public class StatusService(IMapper mapper, IClient httpClient, ILocalStorageService localStorage)
  : BaseHttpService(httpClient, localStorage), IStatusService
{
  public async Task<List<ReferenceDataViewModel>> GetAll()
  {
    ICollection<StatusDto>? statusList = await httpClient.StatusAllAsync();
    return mapper.Map<List<ReferenceDataViewModel>>(statusList);
  }
}
