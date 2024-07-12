namespace Numployable.UI.Web.Models;

using System.ComponentModel.DataAnnotations;

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