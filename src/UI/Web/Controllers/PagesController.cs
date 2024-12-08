using Microsoft.AspNetCore.Mvc;

namespace Numployable.UI.Web.Controllers;

public class PagesController : Controller
{
  public IActionResult AccountSettings()
  {
    return View();
  }

  public IActionResult AccountSettingsConnections()
  {
    return View();
  }

  public IActionResult AccountSettingsNotifications()
  {
    return View();
  }

  public IActionResult MiscError()
  {
    return View();
  }

  public IActionResult MiscUnderMaintenance()
  {
    return View();
  }
}
