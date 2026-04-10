using VeterinariaElAngel.EN;
using Microsoft.EntityFrameworkCore;

namespace VeterinariaElAngel.DAL
{
    public class UsuarioDAL
    {
        public static async Task<int> CrearAsync(Usuario pUsuario)
        {
            using (var db = new ContextoDB())
            {
                db.Add(pUsuario);
                return await db.SaveChangesAsync();
            }
        }

        public static async Task<Usuario> LoginAsync(Usuario pUsuario)
        {
            using (var db = new ContextoDB())
            {
                return await db.Usuario.FirstOrDefaultAsync(s => s.Correo == pUsuario.Correo && s.Password == pUsuario.Password);
            }
        }

        public static async Task<List<Usuario>> ObtenerTodosAsync()
        {
            using (var db = new ContextoDB())
            {
                return await db.Usuario.ToListAsync();
            }
        }
    }
}