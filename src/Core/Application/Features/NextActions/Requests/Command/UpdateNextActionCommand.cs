namespace Numployable.Application.Features.NextActions.Requests.Commands;

using MediatR;

using Numployable.Application.DTOs.NextActions;
using Numployable.Application.Responses;

public class UpdateNextActionCommand : IRequest<BaseCommandResponse>
{
    public UpdateNextActionDto? UpdateNextActionDto { get; set; }
}