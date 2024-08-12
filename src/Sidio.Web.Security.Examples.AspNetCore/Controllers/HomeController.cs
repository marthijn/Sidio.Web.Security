using Microsoft.AspNetCore.Mvc;
using Sidio.Web.Security.Examples.AspNetCore.Models;
using System.Diagnostics;

namespace Sidio.Web.Security.Examples.AspNetCore.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}