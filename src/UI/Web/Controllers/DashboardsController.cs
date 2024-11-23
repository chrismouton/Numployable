using Microsoft.AspNetCore.Mvc;
using Numployable.UI.Web.Contracts;

namespace Numployable.UI.Web.Controllers;

public class DashboardsController(IDashboardService dashboardService)
    : Controller
{
  IDashboardService dashboardService = dashboardService;

  public async Task<IActionResult> Index()
  {
    var model = await dashboardService.Get();

    return View(model);
  }
}
