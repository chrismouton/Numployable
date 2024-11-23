using AutoMapper;
using MediatR;
using Numployable.Application.DTOs.InfrastructureData;
using Numployable.Application.Features.InfrastructureData.Requests.Queries;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Application.Features.InfrastructureData.Handlers.Queries;

public class GetProcessStatusListRequestHandler(IProcessStatusRepository ProcessStatusRepository, IMapper mapper) 
    : IRequestHandler<GetProcessStatusListRequest, List<ProcessStatusDto>>
{
    private readonly IProcessStatusRepository _ProcessStatusRepository = ProcessStatusRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<ProcessStatusDto>> Handle(GetProcessStatusListRequest request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<ProcessStatus> ProcessStatuss = await _ProcessStatusRepository.GetAll();

        return _mapper.Map<List<ProcessStatusDto>>(ProcessStatuss);
    }
}