namespace Numploy.Domain;

public class NextAction : BaseDomainEntity
{
    public NextActionType? NextActionType {get; set; }

    public string? ActionNote { get; set; }

    public DateTime? ActionDate { get; set; }
}