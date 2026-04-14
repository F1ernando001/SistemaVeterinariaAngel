using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinariaElAngel.DAL;
using VeterinariaElAngel.EN;

namespace VeterinariaElAngel.BL
{
    public class StatusBL
    {
        public async Task<int> GuardarAsync(Status pStatus)
        {
            return await StatusDAL.GuardarAsync(pStatus);
        }

        public async Task<int> ModificarAsync(Status pStatus)
        {
            return await StatusDAL.ModificarAsync(pStatus);
        }

        public async Task<int> EliminarAsync(int idStatus)
        {
            return await StatusDAL.EliminarAsync(idStatus);
        }

        public async Task<Status> ObtenerPorIdAsync(int idStatus)
        {
            return await StatusDAL.ObtenerPorIdAsync(idStatus);
        }

        public async Task<List<Status>> ObtenerTodosAsync()
        {
            return await StatusDAL.ObtenerTodosAsync();
        }
    }
}