using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Status : ReferenceDataBase
{
    [InverseProperty("Status")]
    public virtual ICollection<JobApplication> JobApplication { get; set; } = new List<JobApplication>();
}