using MediatR;
using Numployable.Application.DTOs.ReferenceData;

namespace Numployable.Application.Features.ReferenceData.Requests.Queries;

public class GetProcessStatusByDescriptionRequest : IRequest<ProcessStatusDto>
{
    public required string Description { get; set; }
}