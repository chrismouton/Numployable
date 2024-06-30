namespace Numployable.Persistence.Model;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

[Index("Description", Name = "Commute_UNIQUE", IsUnique = true)]
public partial class Commute
{
    [Key]
    [Column(TypeName = "int(10) unsigned")]
    public Numployable.Commute Id { get; set; }

    [StringLength(100)]
    public string Description { get; set; } = null!;

    [InverseProperty("Commute")]
    public virtual ICollection<JobApplication> JobApplication { get; set; } = new List<JobApplication>();
}
