using Numployable.UI.Web.Models;

namespace Numployable.UI.Web.Contracts;

public interface IDashboardService
{
    Task<DashboardViewModel> Get();
}
