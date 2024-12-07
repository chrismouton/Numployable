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
    : IRequestHandler<GetSourceListRequest, IEnumerable<SourceDto>>
{
    public async Task<IEnumerable<SourceDto>> Handle(GetSourceListRequest request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<Source> Sources = await sourceRepository.GetAll();

        return mapper.Map<IEnumerable<SourceDto>>(Sources);
    }
}