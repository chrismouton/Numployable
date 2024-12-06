namespace Numployable.Domain;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RoleType : ReferenceDataBase
{
    [InverseProperty("RoleType")]
    public virtual ICollection<JobApplication> JobApplication { get; set; } = [];
}
