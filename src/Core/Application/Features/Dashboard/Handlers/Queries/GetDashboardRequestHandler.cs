using AutoMapper;
using MediatR;
using Numployable.Application.DTOs.Dashboard;
using Numployable.Application.Features.Dashboard.Requests.Queries;
using Numployable.Application.Persistence.Contracts;

namespace Numployable.Application.Features.Dashboard.Handlers.Queries;

public class GetDashboardRequestHandler(IDashboardRepository dashboardRepository, IMapper mapper) 
    : IRequestHandler<GetDashboardRequest, DashboardDto>
{
    private readonly IDashboardRepository _dashboardRepository = dashboardRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<DashboardDto> Handle(GetDashboardRequest request, CancellationToken cancellationToken)
    {
        var dashboard = await _dashboardRepository.Get();

        return _mapper.Map<DashboardDto>(dashboard);
    }
}