using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinariaElAngel.DAL;
using VeterinariaElAngel.EN;

namespace VeterinariaElAngel.BL
{
    public class CitaBL
    {
        public async Task<int> CrearAsync(Cita pCita)
        {
            return await CitaDAL.GuardarAsync(pCita);
        }

        public async Task<int> ModificarAsync(Cita pCita)
        {
            return await CitaDAL.ModificarAsync(pCita);
        }

        public async Task<int> EliminarAsync(int idCita)
        {
            return await CitaDAL.EliminarAsync(idCita);
        }

        public async Task<Cita> ObtenerPorIdAsync(int idCita)
        {
            return await CitaDAL.ObtenerPorIdAsync(idCita);
        }

        public async Task<List<Cita>> ObtenerTodosAsync()
        {
            return await CitaDAL.ObtenerTodosAsync();
        }
    }
}