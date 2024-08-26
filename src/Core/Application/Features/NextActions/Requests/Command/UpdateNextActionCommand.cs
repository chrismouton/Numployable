namespace Numployable.Application.Features.NextActions.Requests.Commands;

using MediatR;

using Numployable.Application.DTOs.NextActions;
using Responses;

public class UpdateNextActionCommand : IRequest<BaseCommandResponse>
{
    public int Id { get; set; }

    public UpdateNextActionDto? UpdateNextActionDto { get; set; }
}