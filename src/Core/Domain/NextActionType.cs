using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class NextActionType : ReferenceDataBase
{
    [InverseProperty("NextActionType")]
    public virtual ICollection<NextAction> NextAction { get; set; } = new List<NextAction>();
}