namespace Numployable.Application.Features.ReferenceData.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numployable.Application.DTOs.ReferenceData;
using Numployable.Application.Features.ReferenceData.Requests.Queries;
using Persistence.Contracts;
using Domain;

public class GetSourceListRequestHandler(ISourceRepository sourceRepository, IMapper mapper) 
    : IRequestHandler<GetSourceListRequest, List<SourceDto>>
{
    public async Task<List<SourceDto>> Handle(GetSourceListRequest request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<Source> Sources = await sourceRepository.GetAll();

        return mapper.Map<List<SourceDto>>(Sources);
    }
}