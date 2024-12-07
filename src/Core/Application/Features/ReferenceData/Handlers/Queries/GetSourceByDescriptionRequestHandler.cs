namespace Numployable.Application.Features.ReferenceData.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numployable.Application.DTOs.ReferenceData;
using Numployable.Application.Features.ReferenceData.Requests.Queries;
using Persistence.Contracts;
using Domain;

public class GetSourceByDescriptionRequestHandler(ISourceRepository sourceRepository, IMapper mapper) 
    : IRequestHandler<GetSourceByDescriptionRequest, SourceDto>
{
    public async Task<SourceDto> Handle(GetSourceByDescriptionRequest request, CancellationToken cancellationToken)
    {
        Source source = await sourceRepository.GetByDescription(request.Description);

        return mapper.Map<SourceDto>(source);
    }
}