namespace Numployable.Application.DTOs.NextActions;

using Common;
using Numployable.Domain;

public class CreateNextActionDto : BaseDto
{
    public NextActionType? NextActionType {get; set; }

    public string? ActionNote { get; set; }

    public DateTime? ActionDate { get; set; }
}