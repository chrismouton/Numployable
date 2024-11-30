namespace Numployable.Application.Features.InfrastructureData.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numployable.Application.DTOs.InfrastructureData;
using Numployable.Application.Features.InfrastructureData.Requests.Queries;
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