namespace Numployable.Persistence.Model;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

[Index("Description", Name = "ApplicationStatus_UNIQUE", IsUnique = true)]
public partial class Status
{
    [Key]
    [Column(TypeName = "int(10) unsigned")]
    public Numployable.Status Id { get; set; }

    [StringLength(100)]
    public string Description { get; set; } = null!;

    [InverseProperty("Status")]
    public virtual ICollection<JobApplication> JobApplication { get; set; } = new List<JobApplication>();
}
