using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinariaElAngel.DAL;
using VeterinariaElAngel.EN;

namespace VeterinariaElAngel.BL
{
    public class HistorialExamenBL
    {
        public async Task<int> GuardarAsync(HistorialExamen pHistorialExamen)
        {
            return await HistorialExamenDAL.GuardarAsync(pHistorialExamen);
        }

        public async Task<int> ModificarAsync(HistorialExamen pHistorialExamen)
        {
            return await HistorialExamenDAL.ModificarAsync(pHistorialExamen);
        }

        public async Task<int> EliminarAsync(int idHistorialExamen)
        {
            return await HistorialExamenDAL.EliminarAsync(idHistorialExamen);
        }

        public async Task<HistorialExamen> ObtenerPorIdAsync(int idHistorialExamen)
        {
            return await HistorialExamenDAL.ObtenerPorIdAsync(idHistorialExamen);
        }

        public async Task<List<HistorialExamen>> ObtenerTodosAsync()
        {
            return await HistorialExamenDAL.ObtenerTodosAsync();
        }
    }
}