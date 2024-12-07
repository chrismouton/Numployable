using System.ComponentModel.DataAnnotations.Schema;

namespace Numployable.Domain;

public class RoleType : ReferenceDataBase
{
    [InverseProperty("RoleType")]
    public virtual ICollection<JobApplication> JobApplication { get; set; } = [];
}
