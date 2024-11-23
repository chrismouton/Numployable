using AutoMapper;
using MediatR;
using Numployable.Application.DTOs.InfrastructureData;
using Numployable.Application.Features.InfrastructureData.Requests.Queries;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Application.Features.InfrastructureData.Handlers.Queries;

public class GetSourceListRequestHandler(ISourceRepository SourceRepository, IMapper mapper) 
    : IRequestHandler<GetSourceListRequest, List<SourceDto>>
{
    private readonly ISourceRepository _SourceRepository = SourceRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<SourceDto>> Handle(GetSourceListRequest request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<Source> Sources = await _SourceRepository.GetAll();

        return _mapper.Map<List<SourceDto>>(Sources);
    }
}