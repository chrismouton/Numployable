namespace Numployable.Application.Features.InfrastructureData.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numployable.Application.DTOs.InfrastructureData;
using Numployable.Application.Features.InfrastructureData.Requests.Queries;
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