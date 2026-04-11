using Microsoft.AspNetCore.Mvc;
using VeterinariaElAngel.BL;
using VeterinariaElAngel.EN;
public class RolController : Controller
{
    RolBL rolBL = new RolBL();
    public async Task<IActionResult> Index() => View(await rolBL.ObtenerTodosAsync());
    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Rol pRol)
    {
        await rolBL.CrearAsync(pRol);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id) => View(await rolBL.ObtenerPorIdAsync(new Rol { IdRol = id }));

    [HttpPost]
    public async Task<IActionResult> Edit(Rol pRol)
    {
        await rolBL.ModificarAsync(pRol);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id) => View(await rolBL.ObtenerPorIdAsync(new Rol { IdRol = id }));

    [HttpPost]
    public async Task<IActionResult> Delete(int id, Rol pRol)
    {
        await rolBL.EliminarAsync(new Rol { IdRol = id });
        return RedirectToAction(nameof(Index));
    }
}