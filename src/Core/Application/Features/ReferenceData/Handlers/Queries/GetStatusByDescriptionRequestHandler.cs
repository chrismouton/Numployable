namespace Numployable.Application.Features.ReferenceData.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numployable.Application.DTOs.ReferenceData;
using Numployable.Application.Features.ReferenceData.Requests.Queries;
using Persistence.Contracts;
using Domain;

public class GetStatusByDescriptionRequestHandler(IStatusRepository statusRepository, IMapper mapper) 
    : IRequestHandler<GetStatusByDescriptionRequest, StatusDto>
{
    public async Task<StatusDto> Handle(GetStatusByDescriptionRequest request, CancellationToken cancellationToken)
    {
        Status status = await statusRepository.GetByDescription(request.Description);

        return mapper.Map<StatusDto>(status);
    }
}