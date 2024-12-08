using AutoMapper;
using MediatR;
using Numployable.Application.DTOs.ReferenceData;
using Numployable.Application.Features.ReferenceData.Requests.Queries;
using Numployable.Application.Persistence.Contracts;
using Numployable.Domain;

namespace Numployable.Application.Features.ReferenceData.Handlers.Queries;

public class GetNextActionTypeByDescriptionRequestHandler(
    INextActionTypeRepository nextActionTypeRepository,
    IMapper mapper)
    : IRequestHandler<GetNextActionTypeByDescriptionRequest, NextActionTypeDto>
{
    public async Task<NextActionTypeDto> Handle(GetNextActionTypeByDescriptionRequest request,
        CancellationToken cancellationToken)
    {
        NextActionType? nextActionType = await nextActionTypeRepository.GetByDescription(request.Description);

        return mapper.Map<NextActionTypeDto>(nextActionType);
    }
}