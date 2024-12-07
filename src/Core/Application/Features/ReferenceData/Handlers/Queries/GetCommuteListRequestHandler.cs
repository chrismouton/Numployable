namespace Numployable.Application.Features.ReferenceData.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Application.DTOs.ReferenceData;
using Application.Features.ReferenceData.Requests.Queries;
using Domain;
using Persistence.Contracts;

public class GetCommuteListRequestHandler(ICommuteRepository commuteRepository, IMapper mapper) 
    : IRequestHandler<GetCommuteListRequest, List<CommuteDto>>
{
    public async Task<List<CommuteDto>> Handle(GetCommuteListRequest request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<Commute> commuteList = await commuteRepository.GetAll();

        return mapper.Map<List<CommuteDto>>(commuteList);
    }
}