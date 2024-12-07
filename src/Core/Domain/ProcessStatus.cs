using System.ComponentModel.DataAnnotations.Schema;

namespace Numployable.Domain;

public class ProcessStatus : ReferenceDataBase
{
    [InverseProperty("ProcessStatus")]
    public virtual ICollection<JobApplication> JobApplication { get; set; } = new List<JobApplication>();
}