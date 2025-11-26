using AutoMapper;
using Numployable.APIClient.Client;
using Numployable.APIClient.Contracts;
using Numployable.UI.Web.Contracts;
using Numployable.UI.Web.Models;

namespace Numployable.UI.Web.Services;

public class CommuteService(IMapper mapper, IClient httpClient, ILocalStorageService localStorage)
  : BaseHttpService(httpClient, localStorage), ICommuteService
{
  public async Task<List<ReferenceDataViewModel>> GetAll()
  {
    ICollection<CommuteDto>? commuteList = await httpClient.CommuteAllAsync();
    return mapper.Map<List<ReferenceDataViewModel>>(commuteList);
  }
}
