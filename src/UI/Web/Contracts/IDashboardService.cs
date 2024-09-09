namespace Numployable.UI.Web.Contracts;

using Numployable.UI.Web.Models;

public interface IDashboardService
{
    Task<DashboardViewModel> Get();
}
