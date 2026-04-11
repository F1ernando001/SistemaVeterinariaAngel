using VeterinariaElAngel.EN;
using Microsoft.EntityFrameworkCore;

namespace VeterinariaElAngel.DAL
{
    public class EspecieDAL
    {
        public static async Task<int> CrearAsync(Especie pEspecie)
        {
            using (var db = new DBContexto())
            {
                db.Add(pEspecie);
                return await db.SaveChangesAsync();
            }
        }

        public static async Task<int> ModificarAsync(Especie pEspecie)
        {
            using (var db = new DBContexto())
            {
                var especieDb = await db.Especie.FirstOrDefaultAsync(s => s.IdEspecie == pEspecie.IdEspecie);
                especieDb.NombreEspecie = pEspecie.NombreEspecie;
                db.Update(especieDb);
                return await db.SaveChangesAsync();
            }
        }

        public static async Task<List<Especie>> ObtenerTodosAsync()
        {
            using (var db = new DBContexto())
            {
                return await db.Especie.ToListAsync();
            }
        }

        public static async Task<Especie> ObtenerPorIdAsync(int pId)
        {
            using (var db = new DBContexto())
            {
                return await db.Especie.FirstOrDefaultAsync(s => s.IdEspecie == pId);
            }
        }
    }
}