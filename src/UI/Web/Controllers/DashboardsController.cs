namespace Numployable.UI.Web.Controllers;

using Microsoft.AspNetCore.Mvc;
using Numployable.UI.Web.Contracts;

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
