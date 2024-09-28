using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PC2.Models;
using PC2.Data;
using Microsoft.AspNetCore.Mvc;

namespace PC2.Controllers
{
    [Route("[controller]")]
    public class BancoController : Controller
    {
        private readonly ILogger<BancoController> _logger;

        public BancoController(ILogger<BancoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}