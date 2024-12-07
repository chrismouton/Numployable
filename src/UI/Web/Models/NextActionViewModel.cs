using System.ComponentModel.DataAnnotations;
using Numployable.APIClient.Client;

namespace Numployable.UI.Web.Models;

public class NextActionViewModel : CreateNextActionViewModel
{
    public int Id { get; set; }
}

public class CreateNextActionViewModel
{
    [Required]
    public ReferenceDataViewModel NextActionType { get; set; }

    [Required]
    public string ActionNote { get; set; }

    [DataType(DataType.Date)]
    public DateTime ActionDate { get; set; }
}
