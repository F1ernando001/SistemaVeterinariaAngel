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
            return await CitaDAL.CrearAsync(pCita);
        }

        public async Task<int> ModificarAsync(Cita pCita)
        {
            return await CitaDAL.ModificarAsync(pCita);
        }

        public async Task<int> EliminarAsync(Cita pCita)
        {
            return await CitaDAL.EliminarAsync(pCita);
        }

        public async Task<Cita> ObtenerPorIdAsync(Cita pCita)
        {
            return await CitaDAL.ObtenerPorIdAsync(pCita);
        }

        public async Task<List<Cita>> ObtenerTodosAsync()
        {
            return await CitaDAL.ObtenerTodosAsync();
        }

        public async Task<List<Cita>> BuscarAsync(Cita pCita)
        {
            return await CitaDAL.BuscarAsync(pCita);
        }
    }
}