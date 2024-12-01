using AutoMapper;
using MediatR;
using Numployable.Application.DTOs.InfrastructureData;
using Numployable.Application.Features.InfrastructureData.Requests.Queries;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Application.Features.InfrastructureData.Handlers.Queries;

public class GetStatusDetailRequestHandler(IStatusRepository statusRepository, IMapper mapper)
    : IRequestHandler<GetStatusDetailRequest, StatusDto>
{
    public async Task<StatusDto> Handle(GetStatusDetailRequest request, CancellationToken cancellationToken)
    {
        Status status = await statusRepository.Get(request.Id);

        return mapper.Map<StatusDto>(status);
    }
}