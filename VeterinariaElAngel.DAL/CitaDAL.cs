using VeterinariaElAngel.EN;
using Microsoft.EntityFrameworkCore;

namespace VeterinariaElAngel.DAL
{
    public class CitaDAL
    {
        public static async Task<int> CrearAsync(Cita pCita)
        {
            using (var db = new ContextoDB())
            {
                db.Add(pCita);
                return await db.SaveChangesAsync();
            }
        }

        public static async Task<List<Cita>> ObtenerTodosAsync()
        {
            using (var db = new ContextoDB())
            {
                return await db.Cita.ToListAsync();
            }
        }
    }
}

