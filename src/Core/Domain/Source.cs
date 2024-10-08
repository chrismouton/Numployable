namespace Numployable.Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Source : BaseDomainEntity
{
    [StringLength(100)]
    public string Description { get; set; } = null!;

    [InverseProperty("Source")]
    public virtual ICollection<JobApplication> JobApplication { get; set; } = new List<JobApplication>();
}