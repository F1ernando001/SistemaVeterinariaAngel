using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VeterinariaElAngel.BL;
namespace VeterinariaElAngel.UI.Controllers
{
    public class GeneroController : Controller
    {
        GeneroBL generoBL = new GeneroBL();

        public async Task<IActionResult> Index()
        {
            return View(await generoBL.ObtenerTodosAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Genero pGenero)
        {
            await generoBL.CrearAsync(pGenero);
            return RedirectToAction(nameof(Index));
        }
    }
}
