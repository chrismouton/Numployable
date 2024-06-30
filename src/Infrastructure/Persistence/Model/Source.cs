namespace Numployable.Persistence.Model;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

[Index("Description", Name = "Source_UNIQUE", IsUnique = true)]
public partial class Source
{
    [Key]
    [Column(TypeName = "int(10) unsigned")]
    public Numployable.Source Id { get; set; }

    [StringLength(100)]
    public string Description { get; set; } = null!;

    [InverseProperty("Source")]
    public virtual ICollection<JobApplication> JobApplication { get; set; } = new List<JobApplication>();
}
