using AutoMapper;
using Numployable.APIClient.Client;
using Numployable.APIClient.Contracts;
using Numployable.UI.Web.Contracts;
using Numployable.UI.Web.Models;

namespace Numployable.UI.Web.Services;

public class RoleTypeService(IMapper mapper, IClient httpClient, ILocalStorageService localStorage)
  : BaseHttpService(httpClient, localStorage), IRoleTypeService
{
  public async Task<List<InfrastructureDataViewModel>> GetAll()
  {
    var roleTypeList = await _client.RoletypeAllAsync();
    return mapper.Map<List<InfrastructureDataViewModel>>(roleTypeList);
  }
}
