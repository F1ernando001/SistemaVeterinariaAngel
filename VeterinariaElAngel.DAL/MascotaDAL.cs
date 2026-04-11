using VeterinariaElAngel.EN;
using Microsoft.EntityFrameworkCore;

namespace VeterinariaElAngel.DAL
{
    public class MascotaDAL
    {
        public static async Task<int> CrearAsync(Mascota pMascota)
        {
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Add(pMascota);
                return await dbContexto.SaveChangesAsync();
            }
        }
        public static async Task<int> ModificarAsync(Mascota pMascota)
        {
            int resultado = 0;
            using (var dbContexto = new DBContexto())
            {
                var mascota = await dbContexto.Mascota.FirstOrDefaultAsync(m => m.IdMascota == pMascota.IdMascota);
                mascota.Nombre = pMascota.Nombre;
                mascota.Estado = pMascota.Estado;
                mascota.IdGenero = pMascota.IdGenero;
                mascota.IdEspecie = pMascota.IdEspecie;
                mascota.IdRaza = pMascota.IdRaza;
                dbContexto.Update(mascota);
                resultado = await dbContexto.SaveChangesAsync();
            }
            return resultado;
        }
        public static async Task<int> EliminarAsync(Mascota pMascota)
        {
            int resultado = 0;
            using (var dbContexto = new DBContexto())
            {
                var mascota = await dbContexto.Mascota.FirstOrDefaultAsync(m => m.IdMascota == pMascota.IdMascota);
                dbContexto.Mascota.Remove(mascota);
                resultado = await dbContexto.SaveChangesAsync();

            }
            return resultado;
        }
        public static async Task<List<Mascota>> ObtenerTodosAsync()
        {
            using (var dbContexto = new DBContexto())
            {
                return await dbContexto.Mascota.ToListAsync();
            }
        }

        public static async Task<Mascota> ObtenerPorIdAsync(int pId)
        {
            using (var db = new DBContexto())
            {
                return await db.Mascota.FirstOrDefaultAsync(s => s.IdMascota == pId);
            }
        }
    }
}