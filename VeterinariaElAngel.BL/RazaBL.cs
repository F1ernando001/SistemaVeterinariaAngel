using System;
using System.Collections.Generic;
using System.Text;
using VeterinariaElAngel.DAL;
using VeterinariaElAngel.EN;

namespace VeterinariaElAngel.BL
{
    public class RazaBL
    {
        public async Task<int> CrearAsync(Raza pRaza)
        {
            return await RazaDAL.GuardarAsync(pRaza);
        }
        public async Task<int> ModificarAsync(Raza pRaza)
        {
            return await RazaDAL.ModificarAsync(pRaza);
        }
        public async Task<int> EliminarAsync(int pRaza)
        {
            return await RazaDAL.EliminarAsync(pRaza);
        }
        public async Task<Raza> ObtenerPorIdAsync(int pRaza)
        {
            return await RazaDAL.ObtenerPorIdAsync(pRaza);
        }
        public async Task<List<Raza>> ObtenerTodosAsync()
        {
            return await RazaDAL.ObtenerTodosAsync();
        }
    }
}
