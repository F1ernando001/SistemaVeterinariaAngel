using VeterinariaElAngel.EN;
using Microsoft.EntityFrameworkCore;

namespace VeterinariaElAngel.DAL
{
    public class CitaDAL
    {
        public static async Task<int> CrearAsync(Cita pCita)
        {
            using (var db = new DBContexto())
            {
                db.Add(pCita);
                return await db.SaveChangesAsync();
            }
        }

        public static async Task<int> ModificarAsync(Cita pCita)
        {
            using (var db = new DBContexto())
            {
                db.Update(pCita);
                return await db.SaveChangesAsync();
            }
        }

        public static async Task<int> EliminarAsync(Cita pCita)
        {
            using (var db = new DBContexto())
            {
                db.Remove(pCita);
                return await db.SaveChangesAsync();
            }
        }

        public static async Task<Cita> ObtenerPorIdAsync(Cita pCita)
        {
            using (var db = new DBContexto())
            {
                return await db.Cita
                    .FirstOrDefaultAsync(c => c.IdCita == pCita.IdCita);
            }
        }

        public static async Task<List<Cita>> ObtenerTodosAsync()
        {
            using (var db = new DBContexto())
            {
                return await db.Cita.ToListAsync();
            }
        }

        public static async Task<List<Cita>> BuscarAsync(Cita pCita)
        {
            using (var db = new DBContexto())
            {
                var query = db.Cita.AsQueryable();


                if (pCita.FechaCita != DateTime.MinValue)
                    query = query.Where(c => c.FechaCita.Date == pCita.FechaCita.Date);

                if (pCita.HoraCita != DateTime.MinValue)
                {
                    var hora = pCita.HoraCita.TimeOfDay;
                    query = query.Where(c => c.HoraCita.TimeOfDay == hora);
                }

                return await query.ToListAsync();
            }
        }
    }
}

