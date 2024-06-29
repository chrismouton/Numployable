namespace Numployable.Application.DTOs.NextActions;

using Numployable.Application.DTOs.Common;

public class CreateNextActionDto : BaseDto
{
    public NextActionType? NextActionType {get; set; }

    public string? ActionNote { get; set; }

    public DateTime? ActionDate { get; set; }
}