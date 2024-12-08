using AutoMapper;
using MediatR;
using Numployable.Application.DTOs.ReferenceData;
using Numployable.Application.Features.ReferenceData.Requests.Queries;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Application.Features.ReferenceData.Handlers.Queries;

public class GetSourceByDescriptionRequestHandler(ISourceRepository sourceRepository, IMapper mapper)
    : IRequestHandler<GetSourceByDescriptionRequest, SourceDto>
{
    public async Task<SourceDto> Handle(GetSourceByDescriptionRequest request, CancellationToken cancellationToken)
    {
        Source? source = await sourceRepository.GetByDescription(request.Description);

        return mapper.Map<SourceDto>(source);
    }
}