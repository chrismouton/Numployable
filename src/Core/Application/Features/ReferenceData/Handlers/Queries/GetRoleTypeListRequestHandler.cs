using AutoMapper;
using Mediator;
using Numployable.Application.DTOs.ReferenceData;
using Numployable.Application.Features.ReferenceData.Requests.Queries;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Application.Features.ReferenceData.Handlers.Queries;

public class GetRoleTypeListRequestHandler(IRoleTypeRepository roleTypeRepository, IMapper mapper)
    : IQueryHandler<GetRoleTypeListRequest, IEnumerable<RoleTypeDto>>
{
    public async ValueTask<IEnumerable<RoleTypeDto>> Handle(GetRoleTypeListRequest request,
        CancellationToken cancellationToken)
    {
        IReadOnlyCollection<RoleType> roleTypes = await roleTypeRepository.GetAll();

        return mapper.Map<IEnumerable<RoleTypeDto>>(roleTypes);
    }
}