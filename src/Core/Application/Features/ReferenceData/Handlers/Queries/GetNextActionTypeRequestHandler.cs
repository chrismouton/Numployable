namespace Numployable.Application.Features.ReferenceData.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numployable.Application.DTOs.ReferenceData;
using Numployable.Application.Features.ReferenceData.Requests.Queries;
using Persistence.Contracts;
using Domain;

public class GetNextActionTypeListRequestHandler(INextActionTypeRepository nextActionTypeRepository, IMapper mapper) 
    : IRequestHandler<GetNextActionTypeListRequest, List<NextActionTypeDto>>
{
    public async Task<List<NextActionTypeDto>> Handle(GetNextActionTypeListRequest request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<NextActionType> NextActionTypes = await nextActionTypeRepository.GetAll();

        return mapper.Map<List<NextActionTypeDto>>(NextActionTypes);
    }
}