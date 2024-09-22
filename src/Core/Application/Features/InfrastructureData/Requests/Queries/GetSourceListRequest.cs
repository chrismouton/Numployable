namespace Numployable.Application.Features.InfrastructureData.Requests.Queries;

using MediatR;
using Numployable.Application.DTOs.InfrastructureData;

public class GetSourceListRequest : IRequest<List<SourceDto>>
{
}