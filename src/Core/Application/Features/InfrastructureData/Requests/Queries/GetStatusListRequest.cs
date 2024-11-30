namespace Numployable.Application.Features.InfrastructureData.Requests.Queries;

using MediatR;

using Numployable.Application.DTOs.InfrastructureData;

public class GetStatusListRequest : IRequest<List<StatusDto>>
{
}