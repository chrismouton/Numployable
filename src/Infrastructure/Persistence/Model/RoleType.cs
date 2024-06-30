namespace Numployable.Persistence.Model;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

[Index("Description", Name = "RoleType_UNIQUE", IsUnique = true)]
public partial class RoleType
{
    [Key]
    [Column(TypeName = "int(10) unsigned")]
    public Numployable.RoleType Id { get; set; }

    [StringLength(100)]
    public string Description { get; set; } = null!;

    [InverseProperty("RoleType")]
    public virtual ICollection<JobApplication> JobApplication { get; set; } = new List<JobApplication>();
}
