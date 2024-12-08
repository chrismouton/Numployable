using Microsoft.AspNetCore.Mvc;

namespace Numployable.U.Web.Controllers;

public class AuthController : Controller
{
  public IActionResult ForgotPasswordBasic()
  {
    return View();
  }

  public IActionResult LoginBasic()
  {
    return View();
  }

  public IActionResult RegisterBasic()
  {
    return View();
  }
}
