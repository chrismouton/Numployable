namespace Numployable.Persistence.Model;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

[Index("CommuteId", Name = "JobApplication_Commute_FK")]
[Index("ProcessStatusId", Name = "JobApplication_ProcessStatus_FK")]
[Index("RoleTypeId", Name = "JobApplication_RoleType_FK")]
[Index("SourceId", Name = "JobApplication_Source_FK")]
[Index("StatusId", Name = "JobApplication_Status_FK")]
public partial class JobApplication
{
    [Key]
    [Column(TypeName = "int(10) unsigned")]
    public int Id { get; set; }

    [StringLength(255)]
    public string RoleName { get; set; } = null!;

    [StringLength(255)]
    public string CompanyName { get; set; } = null!;

    [Column(TypeName = "int(10) unsigned")]
    public Numployable.RoleType RoleTypeId { get; set; }

    [Column(TypeName = "int(10) unsigned")]
    public Numployable.Status StatusId { get; set; }

    [Column(TypeName = "int(10) unsigned")]
    public Numployable.ProcessStatus ProcessStatusId { get; set; }

    [Column(TypeName = "int(10) unsigned")]
    public Numployable.Source SourceId { get; set; }

    [StringLength(255)]
    public string? AdvertisedSalary { get; set; }

    [StringLength(1024)]
    public string? Url { get; set; }

    [StringLength(255)]
    public string? Location { get; set; }

    [Column(TypeName = "int(10) unsigned")]
    public Numployable.Commute? CommuteId { get; set; }

    [Column(TypeName = "date")]
    public DateTime ApplicationDate { get; set; }

    [StringLength(1024)]
    public string? Note { get; set; }

    [ForeignKey("CommuteId")]
    [InverseProperty("JobApplication")]
    public virtual Commute? Commute { get; set; }

    [InverseProperty("JobApplication")]
    public virtual ICollection<NextAction> NextAction { get; set; } = new List<NextAction>();

    [ForeignKey("ProcessStatusId")]
    [InverseProperty("JobApplication")]
    public virtual ProcessStatus ProcessStatus { get; set; } = null!;

    [ForeignKey("RoleTypeId")]
    [InverseProperty("JobApplication")]
    public virtual RoleType RoleType { get; set; } = null!;

    [ForeignKey("SourceId")]
    [InverseProperty("JobApplication")]
    public virtual Source Source { get; set; } = null!;

    [ForeignKey("StatusId")]
    [InverseProperty("JobApplication")]
    public virtual Status Status { get; set; } = null!;
}
