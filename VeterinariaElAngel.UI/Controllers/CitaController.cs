using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; 
using VeterinariaElAngel.BL; 
using VeterinariaElAngel.EN;


namespace VeterinariaElAngel.UI.Controllers
{
    public class CitaController : Controller
    {
        CitaBL citaBL = new CitaBL();
        MascotaBL mascotaBL = new MascotaBL();
        StatusBL statusBL = new StatusBL();

        public async Task<IActionResult> Index()
        {
            return View(await citaBL.ObtenerTodosAsync());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Mascotas = new SelectList(await mascotaBL.ObtenerTodosAsync(), "IdMascota", "NombreMascota");
            ViewBag.Status = new SelectList(await statusBL.ObtenerTodosAsync(), "IdStatus", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cita pCita)
        {
            if (await citaBL.CrearAsync(pCita) > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(pCita);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cita = await citaBL.ObtenerPorIdAsync(new Cita { IdCita = id });
            if (cita == null) return NotFound();

            ViewBag.Mascotas = new SelectList(await mascotaBL.ObtenerTodosAsync(), "IdMascota", "NombreMascota");
            ViewBag.Status = new SelectList(await statusBL.ObtenerTodosAsync(), "IdStatus", "Nombre");
            return View(cita);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Cita pCita)
        {
            if (await citaBL.ModificarAsync(pCita) > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(pCita);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cita = await citaBL.ObtenerPorIdAsync(new Cita { IdCita = id });
            if (cita == null) return NotFound();
            return View(cita);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Cita pCita)
        {
            await citaBL.EliminarAsync(new Cita { IdCita = id });
            return RedirectToAction(nameof(Index));
        }
    }
}