namespace Numployable.Application.Features.InfrastructureData.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numployable.Application.DTOs.InfrastructureData;
using Numployable.Application.Features.InfrastructureData.Requests.Queries;
using Persistence.Contracts;
using Domain;

public class GetRoleTypeListRequestHandler(IRoleTypeRepository RoleTypeRepository, IMapper mapper) 
    : IRequestHandler<GetRoleTypeListRequest, List<RoleTypeDto>>
{
    private readonly IRoleTypeRepository _RoleTypeRepository = RoleTypeRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<RoleTypeDto>> Handle(GetRoleTypeListRequest request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<RoleType> RoleTypes = await _RoleTypeRepository.GetAll();

        return _mapper.Map<List<RoleTypeDto>>(RoleTypes);
    }
}