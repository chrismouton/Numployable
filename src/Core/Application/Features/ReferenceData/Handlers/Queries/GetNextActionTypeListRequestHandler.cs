using AutoMapper;
using Mediator;
using Numployable.Application.DTOs.ReferenceData;
using Numployable.Application.Features.ReferenceData.Requests.Queries;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Application.Features.ReferenceData.Handlers.Queries;

public class GetNextActionTypeListRequestHandler(INextActionTypeRepository nextActionTypeRepository, IMapper mapper)
    : IQueryHandler<GetNextActionTypeListRequest, IEnumerable<NextActionTypeDto>>
{
    public async ValueTask<IEnumerable<NextActionTypeDto>> Handle(GetNextActionTypeListRequest request,
        CancellationToken cancellationToken)
    {
        IReadOnlyCollection<NextActionType> NextActionTypes = await nextActionTypeRepository.GetAll();

        return mapper.Map<IEnumerable<NextActionTypeDto>>(NextActionTypes);
    }
}