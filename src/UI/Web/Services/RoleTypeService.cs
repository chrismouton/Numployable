using AutoMapper;
using Numployable.APIClient.Client;
using Numployable.APIClient.Contracts;
using Numployable.UI.Web.Contracts;
using Numployable.UI.Web.Models;

namespace Numployable.UI.Web.Services;

public class RoleTypeService(IMapper mapper, IClient httpClient, ILocalStorageService localStorage)
  : BaseHttpService(httpClient, localStorage), IRoleTypeService
{
  public async Task<List<ReferenceDataViewModel>> GetAll()
  {
    ICollection<RoleTypeDto>? roleTypeList = await httpClient.RoletypeAllAsync();
    return mapper.Map<List<ReferenceDataViewModel>>(roleTypeList);
  }
}
