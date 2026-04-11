using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VeterinariaElAngel.BL;
using VeterinariaElAngel.EN;

namespace VeterinariaElAngel.UI.Controllers
{
    public class MascotaController : Controller
    {
        MascotaBL mascotaBL = new MascotaBL();
        EspecieBL especieBL = new EspecieBL();
        RazaBL razaBL = new RazaBL();

        public async Task<IActionResult> Index() => View(await mascotaBL.ObtenerTodosAsync());

        public async Task<IActionResult> Create()
        {
            ViewBag.Especies = await especieBL.ObtenerTodosAsync();
            ViewBag.Razas = await razaBL.ObtenerTodosAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Mascota pM)
        {
            await mascotaBL.CrearAsync(pM);
            return RedirectToAction(nameof(Index));
        }
    }
}
