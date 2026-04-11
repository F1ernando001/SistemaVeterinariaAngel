using Microsoft.AspNetCore.Mvc;
using VeterinariaElAngel.BL;  
using VeterinariaElAngel.EN; 

namespace VeterinariaElAngel.UI.Controllers
{
    public class RolController : Controller
    {
        RolBL rolBL = new RolBL();

        public async Task<IActionResult> Index()
        {
            return View(await rolBL.ObtenerTodosAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Rol pRol)
        {
            await rolBL.CrearAsync(pRol);
            return RedirectToAction(nameof(Index));
        }
    }
}