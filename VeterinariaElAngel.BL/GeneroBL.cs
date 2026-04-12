using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinariaElAngel.DAL;
using VeterinariaElAngel.EN;

namespace VeterinariaElAngel.BL
{
    public class GeneroBL
    {
        public async Task<int> GuardarAsync(Genero pGenero)
        {
            return await GeneroDAL.GuardarAsync(pGenero);
        }

        public async Task<int> ModificarAsync(Genero pGenero)
        {
            return await GeneroDAL.ModificarAsync(pGenero);
        }

        public async Task<int> EliminarAsync(int idGenero)
        {
            return await GeneroDAL.EliminarAsync(idGenero);
        }

        public async Task<Genero> ObtenerPorIdAsync(int idGenero)
        {
            return await GeneroDAL.ObtenerPorIdAsync(idGenero);
        }

        public async Task<List<Genero>> ObtenerTodosAsync()
        {
            return await GeneroDAL.ObtenerTodosAsync();
        }
    }
}