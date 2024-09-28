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
        private readonly ApplicationDbContext _context; // Agregamos el contexto de la base de datos

        public BancoController(ILogger<BancoController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context; // Inyectamos el contexto
        }

        // Acción para mostrar el listado de bancos
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var bancos = await _context.DataBanco.ToListAsync();
            return View(bancos); // Pasamos la lista de bancos a la vista
        }

        // Acción para mostrar el formulario de registro
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // Acción para manejar el registro de un banco
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bancos banco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(banco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirigimos al listado
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