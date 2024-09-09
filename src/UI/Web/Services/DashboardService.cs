namespace Numployable.UI.Web.Services;

using AutoMapper;

using Numployable.UI.Web.Contracts;
using Numployable.UI.Web.Models;
using Numployable.UI.Web.Services.Base;

public class DashboardService(IMapper mapper, IClient httpClient, ILocalStorageService localStorage)
    : BaseHttpService(httpClient, localStorage), IDashboardService
{
    private readonly IMapper _mapper = mapper;

    public async Task<DashboardViewModel> Get()
    {
        var dashboardDto = await _client.DashboardAsync();
        return _mapper.Map<DashboardViewModel>(dashboardDto);
    }
}
