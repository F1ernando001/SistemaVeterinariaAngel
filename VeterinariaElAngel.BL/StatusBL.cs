using System;
using System.Collections.Generic;
using System.Text;
using VeterinariaElAngel.DAL;
using VeterinariaElAngel.EN;

namespace VeterinariaElAngel.BL
{
    public class StatusBL
    {
        public async Task<int> CrearAsync(Status pStatus)
        {
            return await StatusDAL.GuardarAsync(pStatus);
        }
        public async Task<int> ModificarAsync(Status pStatus)
        {
            return await StatusDAL.ModificarAsync(pStatus);
        }
        public async Task<int> EliminarAsync(int pStatus)
        {
            return await StatusDAL.EliminarAsync(pStatus);
        }
        public async Task<Status> ObtenerPorId(int idStatus)
        {
            return await StatusDAL.ObtenerPorIdAsync(idStatus);
        }
        public async Task<List<Status>> ObtenerTodosAsync()
        {
            return await StatusDAL.ObtenerTodosAsync();
        }
    }
}
