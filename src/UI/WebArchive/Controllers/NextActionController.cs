namespace Numployable.UI.Web.Controllers;

using Microsoft.AspNetCore.Mvc;
using Numployable.UI.Web.Contracts;

public class NextActionController(INextActionService nextActionService)
    : Controller
{
    private INextActionService _nextActionService = nextActionService;
    
    // GET: HomeController
    public ActionResult Index()
    {
        return View();
    }

    public ActionResult Details(int id)
    {
        return View();

    }

    public ActionResult Create()
    {
        return View();

    }


}

