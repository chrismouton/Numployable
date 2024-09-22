namespace Numployable.Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Commute : BaseDomainEntity
{
     [StringLength(100)]
    public string Description { get; set; } = null!;

    [InverseProperty("Commute")]
    public virtual ICollection<JobApplication> JobApplication { get; set; } = [];
}