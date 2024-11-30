namespace Numployable.Application.Features.InfrastructureData.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numployable.Application.DTOs.InfrastructureData;
using Numployable.Application.Features.InfrastructureData.Requests.Queries;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

public class GetCommuteByDescriptionRequestHandler(ICommuteRepository commuteRepository, IMapper mapper) 
    : IRequestHandler<GetCommuteByDescriptionRequest, CommuteDto>
{
    public async Task<CommuteDto> Handle(GetCommuteByDescriptionRequest request, CancellationToken cancellationToken)
    {
        Commute commute = await commuteRepository.GetByDescription(request.Description);

        return mapper.Map<CommuteDto>(commute);
    }
}