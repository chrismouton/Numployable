using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ProcessStatus : ReferenceDataBase
{
    [InverseProperty("ProcessStatus")]
    public virtual ICollection<JobApplication> JobApplication { get; set; } = new List<JobApplication>();
}