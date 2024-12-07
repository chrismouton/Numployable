using System.ComponentModel.DataAnnotations.Schema;

namespace Numployable.Domain;

public class Status : ReferenceDataBase
{
    [InverseProperty("Status")]
    public virtual ICollection<JobApplication> JobApplication { get; set; } = new List<JobApplication>();
}