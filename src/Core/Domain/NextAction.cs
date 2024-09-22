namespace Numployable.Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class NextAction : BaseDomainEntity
{
    public int NextActionTypeId { get; set; }

    [StringLength(255)]
    public string ActionNote { get; set; } = null!;

    [Column(TypeName = "timestamp")]
    public DateTime ActionDate { get; set; }

    public int JobApplicationId { get; set; }

    public virtual JobApplication JobApplication { get; set; } = null!;

    public virtual NextActionType NextActionType { get; set; } = null!;
}