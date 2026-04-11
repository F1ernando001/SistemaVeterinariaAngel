using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using VeterinariaElAngel.EN;

namespace VeterinariaElAngel.DAL
{
    public class UsuarioDAL
    {
        private static void EncriptarMD5(Usuario pUsuario)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.UTF8.GetBytes(pUsuario.Password));
                var strEncriptar = "";

                for (int i = 0; i < result.Length; i++)
                {
                    strEncriptar += result[i].ToString("x2").ToLower();
                }

                pUsuario.Password = strEncriptar;
            }
        }
        private static async Task<bool> ExisteEmail(Usuario pUsuario, DBContexto pDBContexto)
        {
            bool result = false;
            var EmailUserExiste = await pDBContexto.Usuario.FirstOrDefaultAsync(a => a.Correo == pUsuario.Correo && a.IdUsuario != pUsuario.IdUsuario);
            if (EmailUserExiste != null && EmailUserExiste.IdUsuario > 0 && EmailUserExiste.Correo == pUsuario.Correo)
                result = true;
            return result;
        }
        #region "CRUD"
        public static async Task<int> GuardarAsync(Usuario pUsuario)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    bool existeEmail = await ExisteEmail(pUsuario, dbContexto);
                    if (existeEmail == false)
                    {
                        EncriptarMD5(pUsuario);
                        dbContexto.Usuario.Add(pUsuario);
                        result = await dbContexto.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("El correo ya existe, ingrese otro correo");
                    }
                }
            }
            catch (Exception ex)
            {
                result = 0;
                throw new Exception(ex.Message);
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Usuario pUsuario)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    bool existeEmail = await ExisteEmail(pUsuario, dbContexto);
                    if (existeEmail == false)
                    {
                        var usuario = await dbContexto.Usuario.FirstOrDefaultAsync(s => s.IdUsuario == pUsuario.IdUsuario);
                        usuario.IdRol = pUsuario.IdRol;
                        usuario.Nombre = pUsuario.Nombre;
                        usuario.Apellido = pUsuario.Apellido;
                        usuario.Correo = pUsuario.Correo;
                        usuario.Estado = pUsuario.Estado;
                        dbContexto.Usuario.Update(usuario);
                        result = await dbContexto.SaveChangesAsync();

                    }
                    else
                    {
                        throw new Exception("El correo ya existe, ingrese otro");
                    }
                }
            }
            catch (Exception ex)
            {
                result = 0;
                throw new Exception(ex.Message);
            }
            return result;
        }
        public static async Task<int> EliminarAsync(int pId)
        {
            int result = 0;
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    var usuario = await dbContexto.Usuario.FirstOrDefaultAsync(s => s.IdUsuario == pId);
                    dbContexto.Usuario.Remove(usuario);
                    result = await dbContexto.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                result = 0;
                throw new Exception("Ocurrió un error interno");
            }
            return result;
        }
        public static async Task<Usuario> ObtenerPorIdAsync(Usuario pUsuario)
        {
            var usuario = new Usuario();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    usuario = await dbContexto.Usuario.FirstOrDefaultAsync(s => s.IdUsuario == pUsuario.IdUsuario);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error interno");
            }
            return usuario;
        }
        public static async Task<List<Usuario>> ObtenerTodosAsync()
        {
            List<Usuario> usuario = new List<Usuario>();
            try
            {
                using (var dbContexto = new DBContexto())
                {
                    usuario = await dbContexto.Usuario.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return usuario;
        }
        internal static IQueryable<Usuario> QuerySelect(IQueryable<Usuario> pQuery, Usuario pUsuario)
        {
            if (pUsuario.IdUsuario > 0)
                pQuery = pQuery.Where(s => s.IdUsuario == pUsuario.IdUsuario);

            if (pUsuario.IdRol > 0)
                pQuery = pQuery.Where(s => s.IdRol == pUsuario.IdRol);

            if (!string.IsNullOrWhiteSpace(pUsuario.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pUsuario.Nombre));

            if (!string.IsNullOrWhiteSpace(pUsuario.Apellido))
                pQuery = pQuery.Where(s => s.Apellido.Contains(pUsuario.Apellido));

            if (!string.IsNullOrWhiteSpace(pUsuario.Correo))
                pQuery = pQuery.Where(s => s.Correo == pUsuario.Correo);

            if (pUsuario.Estado)
                pQuery = pQuery.Where(s => s.Estado == true);


            pQuery = pQuery.OrderByDescending(s => s.IdUsuario).AsQueryable();

            return pQuery;
        }
        public static async Task<List<Usuario>> BuscarAsync(Usuario pUsuario)
        {
            var usuario = new List<Usuario>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Usuario.AsQueryable();
                select = QuerySelect(select, pUsuario);
                usuario = await select.ToListAsync();
            }
            return usuario;
        }
        #endregion
        public static async Task<List<Usuario>> BuscarIncluirRolesAsync(Usuario pUsuario)
        {
            var usuario = new List<Usuario>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Usuario.AsQueryable();
                select = QuerySelect(select, pUsuario)
                         .Include(s => s.Rol)
                         .AsQueryable();

                usuario = await select.ToListAsync();
            }
            return usuario;
        }
        public static async Task<Usuario> EmailAsync(Usuario pUsuario)
        {
            var usuario = new Usuario();
            using (var dbContexto = new DBContexto())
            {
                EncriptarMD5(pUsuario);

                usuario = await dbContexto.Usuario.FirstOrDefaultAsync(s =>
                    s.Correo == pUsuario.Correo &&
                    s.Password == pUsuario.Password &&
                    s.Estado == true);
            }
            return usuario;
        }
    }
}