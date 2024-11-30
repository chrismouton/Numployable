namespace Numployable.Application.Features.InfrastructureData.Handlers.Queries;

using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using Numployable.Application.DTOs.InfrastructureData;
using Numployable.Application.Features.InfrastructureData.Requests.Queries;
using Persistence.Contracts;
using Domain;

public class GetNextActionTypeByDescriptionRequestHandler(INextActionTypeRepository nextActionTypeRepository, IMapper mapper) 
    : IRequestHandler<GetNextActionTypeByDescriptionRequest, NextActionTypeDto>
{
    public async Task<NextActionTypeDto> Handle(GetNextActionTypeByDescriptionRequest request, CancellationToken cancellationToken)
    {
        NextActionType nextActionType = await nextActionTypeRepository.GetByDescription(request.Description);

        return mapper.Map<NextActionTypeDto>(nextActionType);
    }
}