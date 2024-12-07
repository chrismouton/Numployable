using System.ComponentModel.DataAnnotations.Schema;

namespace Numployable.Domain;

public class NextActionType : ReferenceDataBase
{
    [InverseProperty("NextActionType")]
    public virtual ICollection<NextAction> NextAction { get; set; } = new List<NextAction>();
}