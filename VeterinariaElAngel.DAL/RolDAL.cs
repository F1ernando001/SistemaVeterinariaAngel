using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VeterinariaElAngel.EN;

namespace VeterinariaElAngel.DAL
{
    public class RolDAL
    {
        public static async Task<int> CrearAsync(Rol pRol)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pRol);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Rol pRol)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var rol = await dbContexto.Rol.FirstOrDefaultAsync(s => s.IdRol == pRol.IdRol);
                rol.TipoRol = pRol.TipoRol;
                dbContexto.Update(rol);
                result = await dbContexto.SaveChangesAsync();
            }

            return result;
        }
        public static async Task<int> EliminarAsync(Rol pRol)
        {
            int result = 0;
            using (var dbContexto = new DBContexto())
            {
                var rol = await dbContexto.Rol.FirstOrDefaultAsync(r => r.IdRol == pRol.IdRol);
                dbContexto.Rol.Remove(rol);
                result = await dbContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Rol> ObtenerPorId(Rol pRol)
        {
            Rol rol = new Rol();
            using (var dbContexto = new DBContexto())
            {
                rol = await dbContexto.Rol.FirstOrDefaultAsync(r => r.IdRol == pRol.IdRol);
            }
            return rol;
        }
        public static async Task<List<Rol>> ObtenerTodosAsync()
        {
            List<Rol> roles = new List<Rol>();
            using (var dbContexto = new DBContexto())
            {
                roles = await dbContexto.Rol.ToListAsync();
            }
            return roles;
        }
        internal static IQueryable<Rol> QuerySelect(IQueryable<Rol> pQuery, Rol pRol)
        {
            if (pRol.IdRol > 0)
                pQuery = pQuery.Where(s => s.IdRol == pRol.IdRol);

            if (!string.IsNullOrWhiteSpace(pRol.TipoRol))
                pQuery = pQuery.Where(s => s.TipoRol.Contains(pRol.TipoRol));

            if (pRol.Estado != null)
                pQuery = pQuery.Where(s => s.Estado == pRol.Estado);

            return pQuery;
        }
        public static async Task<List<Rol>> BuscarAsync(Rol pRol)
        {
            var roles = new List<Rol>();
            using (var dbContexto = new DBContexto())
            {
                var select = dbContexto.Rol.AsQueryable();
                select = QuerySelect(select, pRol);
                roles = await select.ToListAsync();
            }
            return roles;
        }
    }
}
