using ECommerce.UI.Models;
using ECommerce.UI.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ECommerce.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GlobalResource _globalResource;

        public HomeController(ILogger<HomeController> logger,
                              GlobalResource globalResource)
        {
            _logger = logger;
            _globalResource = globalResource;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            string k = _globalResource.Get("Home");
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
}