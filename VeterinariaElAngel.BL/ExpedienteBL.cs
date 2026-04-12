using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinariaElAngel.DAL;
using VeterinariaElAngel.EN;

namespace VeterinariaElAngel.BL
{
    public class ExpedienteBL
    {
        public async Task<int> GuardarAsync(Expediente pExpediente)
        {
            return await ExpedienteDAL.GuardarAsync(pExpediente);
        }

        public async Task<int> ModificarAsync(Expediente pExpediente)
        {
            return await ExpedienteDAL.ModificarAsync(pExpediente);
        }

        public async Task<int> EliminarAsync(int idExpediente)
        {
            return await ExpedienteDAL.EliminarAsync(idExpediente);
        }

        public async Task<Expediente> ObtenerPorIdAsync(int idExpediente)
        {
            return await ExpedienteDAL.ObtenerPorIdAsync(idExpediente);
        }

        public async Task<List<Expediente>> ObtenerTodosAsync()
        {
            return await ExpedienteDAL.ObtenerTodosAsync();
        }
    }
}