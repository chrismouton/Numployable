namespace Numploy.Application.Features.NextActions.Requests.Commands;

using MediatR;

using Numploy.Application.DTOs.NextActions;
using Numploy.Application.Responses;

public class CreateNextActionCommand : IRequest<BaseCommandResponse>
{
    public CreateNextActionDto? CreateNextActionDto { get; set; }
}