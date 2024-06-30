namespace Numployable.Persistence.Model;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

[Index("Description", Name = "ApplicationProcessStatus_UNIQUE", IsUnique = true)]
public partial class ProcessStatus
{
    [Key]
    [Column(TypeName = "int(10) unsigned")]
    public Numployable.ProcessStatus Id { get; set; }

    [StringLength(100)]
    public string Description { get; set; } = null!;

    [InverseProperty("ProcessStatus")]
    public virtual ICollection<JobApplication> JobApplication { get; set; } = new List<JobApplication>();
}
