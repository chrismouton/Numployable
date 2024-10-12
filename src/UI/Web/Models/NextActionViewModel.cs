namespace Numployable.UI.Web.Models;

using System.ComponentModel.DataAnnotations;

using Numployable.UI.Web.Services.Base;

public class NextActionViewModel : CreateNextActionViewModel
{
    public int Id { get; set; }
}

public class CreateNextActionViewModel
{
    [Required]
    public required NextActionType NextActionType { get; set; }

    [Required]
    public required string ActionNote { get; set; }

    [DataType(DataType.Date)]
    public required DateTime ActionDate { get; set; }
}
