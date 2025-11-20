using AutoMapper;
using Mediator;
using Numployable.Application.DTOs.ReferenceData;
using Numployable.Application.Features.ReferenceData.Requests.Queries;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Application.Features.ReferenceData.Handlers.Queries;

public class GetRoleTypeByDescriptionRequestHandler(IRoleTypeRepository roleTypeRepository, IMapper mapper)
    : IRequestHandler<GetRoleTypeByDescriptionRequest, RoleTypeDto>
{
    public async ValueTask<RoleTypeDto> Handle(GetRoleTypeByDescriptionRequest request, CancellationToken cancellationToken)
    {
        RoleType? roleType = await roleTypeRepository.GetByDescription(request.Description);

        return mapper.Map<RoleTypeDto>(roleType);
    }
}