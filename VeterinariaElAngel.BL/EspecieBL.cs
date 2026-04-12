using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinariaElAngel.DAL;
using VeterinariaElAngel.EN;

namespace VeterinariaElAngel.BL
{
    public class EspecieBL
    {
        public async Task<int> GuardarAsync(Especie pEspecie)
        {
            return await EspecieDAL.CrearAsync(pEspecie);
        }

        public async Task<int> ModificarAsync(Especie pEspecie)
        {
            return await EspecieDAL.ModificarAsync(pEspecie);
        }

        public async Task<int> EliminarAsync(Especie pEspecie)
        {
            return await EspecieDAL.EliminarAsync(pEspecie);
        }

        public async Task<Especie> ObtenerPorIdAsync(int idEspecie)
        {
            return await EspecieDAL.ObtenerPorIdAsync(idEspecie);
        }

        public async Task<List<Especie>> ObtenerTodosAsync()
        {
            return await EspecieDAL.ObtenerTodosAsync();
        }
    }
}