using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VeterinariaElAngel.BL;
using VeterinariaElAngel.EN;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
namespace VeterinariaElAngel.UI.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioBL usuarioBL = new UsuarioBL();
        RolBL rolBL = new RolBL();

        public async Task<IActionResult> Index(Usuario pUsuario)
        {
            if(pUsuario == null) pUsuario = new Usuario();

            if (pUsuario.top_Aux == 0) pUsuario.top_Aux = 10;

            else if (pUsuario.top_Aux == -1) pUsuario.top_Aux = 0;

            var taskBuscar = usuarioBL.BuscarIncluirRolesAsync(pUsuario);
            var taskObtenerTodos = usuarioBL.ObtenerTodosAsync();
            var usuarios = await taskBuscar;
            ViewBag.Top = pUsuario.top_Aux;
            ViewBag.Roles = await taskObtenerTodos;
            return View(usuarios);
         
        }
        public async Task<IActionResult> Details(int id)
        {
            var usuario = await usuarioBL.ObtenerPorIdAsync(new Usuario { IdUsuario = id });
            usuario.Rol = await rolBL.ObtenerPorId(new Rol { IdRol = usuario.IdRol });
            return View(usuario);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Roles = await rolBL.ObtenerTodosAsync();
            ViewBag.Error = "";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario pUsuario)
        {
            try
            {
                int result = await usuarioBL.CrearAsync(pUsuario);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Roles = await rolBL.ObtenerTodosAsync();
                return View(pUsuario);
            }
        }
        public async Task<IActionResult> Edit(Usuario pUsuario)
        {
            var taskObtenerPorId = usuarioBL.ObtenerPorIdAsync(pUsuario);
            var taskObtenerTodosRoles = usuarioBL.ObtenerTodosAsync();
            var usuario = await taskObtenerPorId;
            ViewBag.Roles = await taskObtenerTodosRoles;
            ViewBag.Error = "";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Usuario pUsuario)
        {
            try
            {
                int result = await usuarioBL.ModificarAsync(pUsuario);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Roles = await rolBL.ObtenerTodosAsync();
                return View(pUsuario);
            }
        }
        public async Task<IActionResult> Delete(Usuario pUsuario)
        {
            var usuario = await usuarioBL.ObtenerPorIdAsync(pUsuario);
            usuario.Rol = await rolBL.ObtenerPorId(new Rol { IdRol = usuario.IdRol });
            ViewBag.Error = "";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Usuario pUsuario)
        {
            try
            {
                int result = await usuarioBL.EliminarAsync(pUsuario);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                var usuario = await usuarioBL.ObtenerPorIdAsync(pUsuario);
                if (usuario == null)
                    usuario = new Usuario();
                if (usuario.IdUsuario > 0) 
                    usuario.Rol = await rolBL.ObtenerPorId(new Rol { IdRol = usuario.IdRol });
                return View(usuario);
            }
        }
        [AllowAnonymous]
        public async Task<IActionResult> Email(string ReturnUrl = null)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            ViewBag.Url = ReturnUrl;
            ViewBag.Error = "";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Email(Usuario pUsuario, string ReturnUrl = null)
        {
            try
            {
                var usuario = await usuarioBL.EmailAsync(pUsuario);
                if (usuario != null && usuario.IdUsuario > 0 && pUsuario.Correo == usuario.Correo)
                {
                    usuario.Rol = await rolBL.ObtenerPorId(new Rol { IdRol = usuario.IdRol });
                    var claims = new[] { new Claim(ClaimTypes.Name, usuario.Correo), new Claim(ClaimTypes.Role, usuario.Rol.TipoRol) };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                }
                else
                    throw new Exception("Credenciales incorrectas");
                if (!string.IsNullOrWhiteSpace(ReturnUrl))
                    return Redirect(ReturnUrl);
                else
                    return RedirectToAction("Index", "Home");
            }
            catch (Exception ex) 
            {
                ViewBag.Url = ReturnUrl;
                ViewBag.Error = ex.Message;
                return View(new Usuario { Correo = pUsuario.Correo});

            }
        }
    }
}