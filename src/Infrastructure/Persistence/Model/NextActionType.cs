namespace Numployable.Persistence.Model;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

[Index("Description", Name = "NextActionType_UNIQUE", IsUnique = true)]
public partial class NextActionType
{
    [Key]
    [Column(TypeName = "int(10) unsigned")]
    public Numployable.NextActionType Id { get; set; }

    [StringLength(100)]
    public string Description { get; set; } = null!;

    [InverseProperty("NextActionType")]
    public virtual ICollection<NextAction> NextAction { get; set; } = new List<NextAction>();
}
