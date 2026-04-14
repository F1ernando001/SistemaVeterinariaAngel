using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinariaElAngel.DAL;
using VeterinariaElAngel.EN;

namespace VeterinariaElAngel.BL
{
    public class RazaBL
    {
        public async Task<int> GuardarAsync(Raza pRaza)
        {
            return await RazaDAL.GuardarAsync(pRaza);
        }

        public async Task<int> ModificarAsync(Raza pRaza)
        {
            return await RazaDAL.ModificarAsync(pRaza);
        }

        public async Task<int> EliminarAsync(int idRaza)
        {
            return await RazaDAL.EliminarAsync(idRaza);
        }

        public async Task<Raza> ObtenerPorIdAsync(int idRaza)
        {
            return await RazaDAL.ObtenerPorIdAsync(idRaza);
        }

        public async Task<List<Raza>> ObtenerTodosAsync()
        {
            return await RazaDAL.ObtenerTodosAsync();
        }
    }
}