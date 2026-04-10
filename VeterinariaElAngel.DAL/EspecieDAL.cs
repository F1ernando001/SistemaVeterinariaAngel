using VeterinariaElAngel.EN;
using Microsoft.EntityFrameworkCore;

namespace VeterinariaElAngel.DAL
{
    public class EspecieDAL
    {
        public static async Task<int> CrearAsync(Especie pEspecie)
        {
            using (var db = new ContextoDB())
            {
                db.Add(pEspecie);
                return await db.SaveChangesAsync();
            }
        }

        public static async Task<int> ModificarAsync(Especie pEspecie)
        {
            using (var db = new ContextoDB())
            {
                var especieDb = await db.Especie.FirstOrDefaultAsync(s => s.IdEspecie == pEspecie.IdEspecie);
                especieDb.Nombre = pEspecie.Nombre;
                db.Update(especieDb);
                return await db.SaveChangesAsync();
            }
        }

        public static async Task<List<Especie>> ObtenerTodosAsync()
        {
            using (var db = new ContextoDB())
            {
                return await db.Especie.ToListAsync();
            }
        }

        public static async Task<Especie> ObtenerPorIdAsync(int pId)
        {
            using (var db = new ContextoDB())
            {
                return await db.Especie.FirstOrDefaultAsync(s => s.IdEspecie == pId);
            }
        }
    }
}