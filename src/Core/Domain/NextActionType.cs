using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Numployable.Domain;

public class NextActionType : BaseDomainEntity
{
    [StringLength(100)]
    public string Description { get; set; } = null!;

    [InverseProperty("NextActionType")]
    public virtual ICollection<NextAction> NextAction { get; set; } = new List<NextAction>();
}