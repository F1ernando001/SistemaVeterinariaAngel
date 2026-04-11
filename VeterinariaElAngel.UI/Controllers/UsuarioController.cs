using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VeterinariaElAngel.BL;
using VeterinariaElAngel.EN;

namespace VeterinariaElAngel.UI.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioBL usuarioBL = new UsuarioBL();
        RolBL rolBL = new RolBL();

        public async Task<IActionResult> Index()
        {
            return View(await usuarioBL.ObtenerTodosAsync());
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Roles = new SelectList(await rolBL.ObtenerTodosAsync(), "IdRol", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario pUsuario)
        {
            await usuarioBL.CrearAsync(pUsuario);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await usuarioBL.ObtenerPorIdAsync(new Usuario { IdUsuario = id });
            ViewBag.Roles = new SelectList(await rolBL.ObtenerTodosAsync(), "IdRol", "Nombre");
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Usuario pUsuario)
        {
            await usuarioBL.ModificarAsync(pUsuario);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await usuarioBL.ObtenerPorIdAsync(new Usuario { IdUsuario = id }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Usuario pUsuario)
        {
            await usuarioBL.EliminarAsync(new Usuario { IdUsuario = id });
            return RedirectToAction(nameof(Index));
        }
    }
}