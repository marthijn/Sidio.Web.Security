using Microsoft.AspNetCore.Mvc;
using Sidio.Web.Security.Examples.AspNetCore.Models;
using System.Diagnostics;
using System.Text.Json;
using Sidio.Web.Security.AspNetCore.Reporting;

namespace Sidio.Web.Security.Examples.AspNetCore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Report([FromBody] Reports model)
    {
        _logger.LogWarning("Report sent from browser: {Report}", JsonSerializer.Serialize(model));
        return Ok();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}