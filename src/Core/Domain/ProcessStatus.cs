using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Numployable.Domain;

public class ProcessStatus : BaseDomainEntity
{
    [StringLength(100)]
    public string Description { get; set; } = null!;

    // [InverseProperty("ProcessStatus")]
    // public virtual ICollection<JobApplication> JobApplication { get; set; } = new List<JobApplication>();
}