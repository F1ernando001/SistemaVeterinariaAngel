using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinariaElAngel.DAL;
using VeterinariaElAngel.EN;

namespace VeterinariaElAngel.BL
{
    public class MascotaBL
    {
        public async Task<int> CrearAsync(Mascota pMascota)
        {
            return await MascotaDAL.CrearAsync(pMascota);
        }

        public async Task<int> ModificarAsync(Mascota pMascota)
        {
            return await MascotaDAL.ModificarAsync(pMascota);
        }

        public async Task<int> EliminarAsync(Mascota pMascota)
        {
            return await MascotaDAL.EliminarAsync(pMascota);
        }

        public async Task<Mascota> ObtenerPorIdAsync(int idMascota)
        {
            return await MascotaDAL.ObtenerPorIdAsync(idMascota);
        }

        public async Task<List<Mascota>> ObtenerTodosAsync()
        {
            return await MascotaDAL.ObtenerTodosAsync();
        }
    }
}