using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinhaPadoca.Models;
using MinhaPadoca.Services.Padaria;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaPadoca.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBakeryService _bakeryService;

        public HomeController(ILogger<HomeController> logger, IBakeryService bakeryService)
        {
            _logger = logger;
            _bakeryService = bakeryService;
        }

        public IActionResult Index()
        {
            var bakeries = _bakeryService.GetAll();
          
            return View(bakeries);
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
