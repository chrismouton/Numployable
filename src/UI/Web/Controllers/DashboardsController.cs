using Microsoft.AspNetCore.Mvc;
using Numployable.UI.Web.Contracts;
using Numployable.UI.Web.Models;

namespace Numployable.UI.Web.Controllers;

public class DashboardsController(IDashboardService dashboardService)
  : Controller
{
  private readonly IDashboardService dashboardService = dashboardService;

  public async Task<IActionResult> Index()
  {
    DashboardViewModel? model = await dashboardService.Get();

    return View(model);
  }
}
