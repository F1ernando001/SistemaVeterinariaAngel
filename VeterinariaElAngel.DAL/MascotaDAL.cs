using VeterinariaElAngel.EN;
using Microsoft.EntityFrameworkCore;

namespace VeterinariaElAngel.DAL
{
    public class MascotaDAL
    {
        public static async Task<int> CrearAsync(Mascota pMascota)
        {
            using (var db = new ContextoDB())
            {
                db.Add(pMascota);
                return await db.SaveChangesAsync();
            }
        }

        public static async Task<List<Mascota>> ObtenerTodosAsync()
        {
            using (var db = new ContextoDB())
            {
                return await db.Mascota.ToListAsync();
            }
        }

        public static async Task<Mascota> ObtenerPorIdAsync(int pId)
        {
            using (var db = new ContextoDB())
            {
                return await db.Mascota.FirstOrDefaultAsync(s => s.IdMascota == pId);
            }
        }
    }
}