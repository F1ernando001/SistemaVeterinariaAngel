using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VeterinariaElAngel.BL; 
using VeterinariaElAngel.EN; 

namespace VeterinariaElAngel.UI.Controllers
{
    public class RazaController : Controller
    {
        RazaBL razaBL = new RazaBL();
        EspecieBL especieBL = new EspecieBL();

        public async Task<IActionResult> Index()
        {
            return View(await razaBL.ObtenerTodosAsync());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Especies = new SelectList(await especieBL.ObtenerTodosAsync(), "IdEspecie", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Raza pRaza)
        {
            await razaBL.CrearAsync(pRaza);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var raza = await razaBL.ObtenerPorIdAsync(new Raza { IdRaza = id });
            ViewBag.Especies = new SelectList(await especieBL.ObtenerTodosAsync(), "IdEspecie", "Nombre");
            return View(raza);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Raza pRaza)
        {
            await razaBL.ModificarAsync(pRaza);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await razaBL.ObtenerPorIdAsync(new Raza { IdRaza = id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Raza pRaza)
        {
            await razaBL.EliminarAsync(new Raza { IdRaza = id });
            return RedirectToAction(nameof(Index));
        }
    }
}