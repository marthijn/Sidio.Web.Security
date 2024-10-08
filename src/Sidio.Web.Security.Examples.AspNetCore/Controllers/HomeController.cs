using Microsoft.AspNetCore.Mvc;
using Sidio.Web.Security.Examples.AspNetCore.Models;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Sidio.Web.Security.AspNetCore.Reporting;

namespace Sidio.Web.Security.Examples.AspNetCore.Controllers;

[ExcludeFromCodeCoverage]
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

    public IActionResult ExternalResources()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Report([FromBody] Reports model)
    {
        if (ModelState.IsValid)
        {
            _logger.LogWarning("Report sent from browser: {Report}", JsonSerializer.Serialize(model));
            return Ok();
        }

        return BadRequest();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}