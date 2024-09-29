using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC2.Models;
using PC2.Data;

namespace PC2.Controllers
{
    [Route("[controller]")]
    public class BancoController : Controller
    {
        private readonly ILogger<BancoController> _logger;
        private readonly ApplicationDbContext _context; 

        public BancoController(ILogger<BancoController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context; 
        }

 
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var bancos = await _context.DataBanco.ToListAsync();
            return View(bancos); 
        }


        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bancos banco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(banco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); 
            }
            return View(banco);
        }
        [HttpGet("Error")]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}