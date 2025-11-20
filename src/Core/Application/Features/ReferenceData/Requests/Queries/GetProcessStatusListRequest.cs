using Mediator;
using Numployable.Application.DTOs.ReferenceData;

namespace Numployable.Application.Features.ReferenceData.Requests.Queries;

public class GetProcessStatusListRequest : IRequest<List<ProcessStatusDto>>
{
}