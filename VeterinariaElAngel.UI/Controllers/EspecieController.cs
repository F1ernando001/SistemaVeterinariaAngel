using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VeterinariaElAngel.BL;
using VeterinariaElAngel.EN;


namespace VeterinariaElAngel.UI.Controllers
{
    public class EspecieController : Controller
    {
        EspecieBL especieBL = new EspecieBL();

        public async Task<IActionResult> Index()
        {
            var especies = await especieBL.ObtenerTodosAsync();
            return View(especies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Especie pEspecie)
        {
            int resultado = await especieBL.CrearAsync(pEspecie);
            if (resultado > 0)
                return RedirectToAction(nameof(Index));

            return View(pEspecie);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var especie = await especieBL.ObtenerPorIdAsync(new Especie { IdEspecie = id });
            if (especie == null) return NotFound();

            return View(especie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Especie pEspecie)
        {
            int resultado = await especieBL.ModificarAsync(pEspecie);
            if (resultado > 0)
                return RedirectToAction(nameof(Index));

            return View(pEspecie);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var especie = await especieBL.ObtenerPorIdAsync(new Especie { IdEspecie = id });
            if (especie == null) return NotFound();

            return View(especie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Especie pEspecie)
        {
            int resultado = await especieBL.EliminarAsync(new Especie { IdEspecie = id });
            return RedirectToAction(nameof(Index));
        }
    }
}
