namespace Numployable.Persistence.Model;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

[Index("JobApplicationId", Name = "NextAction_JobApplication_FK")]
[Index("NextActionTypeId", Name = "NextAction_NextActionType_FK")]
public partial class NextAction
{
    [Key]
    [Column(TypeName = "int(10) unsigned")]
    public int Id { get; set; }

    [Column(TypeName = "int(10) unsigned")]
    public Numployable.NextActionType NextActionTypeId { get; set; }

    [StringLength(255)]
    public string ActionNote { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime ActionDate { get; set; }

    [Column(TypeName = "int(10) unsigned")]
    public int JobApplicationId { get; set; }

    [ForeignKey("JobApplicationId")]
    [InverseProperty("NextAction")]
    public virtual JobApplication JobApplication { get; set; } = null!;

    [ForeignKey("NextActionTypeId")]
    [InverseProperty("NextAction")]
    public virtual NextActionType NextActionType { get; set; } = null!;
}
