namespace Numployable.Application.Features.InfrastructureData.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numployable.Application.DTOs.InfrastructureData;
using Numployable.Application.Features.InfrastructureData.Requests.Queries;
using Persistence.Contracts;
using Domain;

public class GetRoleTypeListRequestHandler(IRoleTypeRepository roleTypeRepository, IMapper mapper) 
    : IRequestHandler<GetRoleTypeListRequest, List<RoleTypeDto>>
{
    public async Task<List<RoleTypeDto>> Handle(GetRoleTypeListRequest request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<RoleType> roleTypes = await roleTypeRepository.GetAll();

        return mapper.Map<List<RoleTypeDto>>(roleTypes);
    }
}