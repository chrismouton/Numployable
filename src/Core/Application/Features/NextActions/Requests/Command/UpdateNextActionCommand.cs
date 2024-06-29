namespace Numploy.Application.Features.NextActions.Requests.Commands;

using MediatR;

using Numploy.Application.DTOs.NextActions;
using Numploy.Application.Responses;

public class UpdateNextActionCommand : IRequest<BaseCommandResponse>
{
    public UpdateNextActionDto? UpdateNextActionDto { get; set; }
}