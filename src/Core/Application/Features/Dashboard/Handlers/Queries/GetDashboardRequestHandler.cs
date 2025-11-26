using AutoMapper;
using Mediator;
using Numployable.Application.DTOs.Dashboard;
using Numployable.Application.Features.Dashboard.Requests.Queries;
using Numployable.Application.Persistence.Contracts;

namespace Numployable.Application.Features.Dashboard.Handlers.Queries;

public class GetDashboardRequestHandler(IDashboardRepository dashboardRepository, IMapper mapper)
    : IQueryHandler<GetDashboardRequest, DashboardDto>
{
    private readonly IDashboardRepository _dashboardRepository = dashboardRepository;

    public async ValueTask<DashboardDto> Handle(GetDashboardRequest request, CancellationToken cancellationToken)
    {
        Domain.Dashboard? dashboard = await _dashboardRepository.Get();

        return mapper.Map<DashboardDto>(dashboard);
    }
}