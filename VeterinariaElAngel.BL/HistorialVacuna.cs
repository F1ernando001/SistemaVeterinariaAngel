using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinariaElAngel.DAL;
using VeterinariaElAngel.EN;

namespace VeterinariaElAngel.BL
{
    public class HistorialVacunaBL
    {
        public async Task<int> GuardarAsync(HistorialVacuna pHistorialVacuna)
        {
            return await HistorialVacunaDAL.GuardarAsync(pHistorialVacuna);
        }

        public async Task<int> ModificarAsync(HistorialVacuna pHistorialVacuna)
        {
            return await HistorialVacunaDAL.ModificarAsync(pHistorialVacuna);
        }

        public async Task<int> EliminarAsync(int idHistorialVacuna)
        {
            return await HistorialVacunaDAL.EliminarAsync(idHistorialVacuna);
        }

        public async Task<HistorialVacuna> ObtenerPorIdAsync(int idHistorialVacuna)
        {
            return await HistorialVacunaDAL.ObtenerPorIdAsync(idHistorialVacuna);
        }

        public async Task<List<HistorialVacuna>> ObtenerTodosAsync()
        {
            return await HistorialVacunaDAL.ObtenerTodosAsync();
        }
    }
}