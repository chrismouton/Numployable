namespace Numployable.Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RoleType : BaseDomainEntity
{
    [StringLength(100)]
    public string Description { get; set; } = null!;

    [InverseProperty("RoleType")]
    public virtual ICollection<JobApplication> JobApplication { get; set; } = [];
}
