namespace Numployable.Application.Features.InfrastructureData.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numployable.Application.DTOs.InfrastructureData;
using Numployable.Application.Features.InfrastructureData.Requests.Queries;
using Persistence.Contracts;
using Domain;

public class GetRoleTypeByDescriptionRequestHandler(IRoleTypeRepository roleTypeRepository, IMapper mapper) 
    : IRequestHandler<GetRoleTypeByDescriptionRequest, RoleTypeDto>
{
    public async Task<RoleTypeDto> Handle(GetRoleTypeByDescriptionRequest request, CancellationToken cancellationToken)
    {
        RoleType roleType = await roleTypeRepository.GetByDescription(request.Description);

        return mapper.Map<RoleTypeDto>(roleType);
    }
}