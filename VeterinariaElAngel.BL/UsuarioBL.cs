using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VeterinariaElAngel.DAL;
using VeterinariaElAngel.EN;

namespace VeterinariaElAngel.BL
{
    public class UsuarioBL
    {
        public async Task<int> CrearAsync(Usuario pUsuario)
        {
            return await UsuarioDAL.GuardarAsync(pUsuario);
        }
        public async Task<int> ModificarAsync(Usuario pUsuario)
        {
            return await UsuarioDAL.ModificarAsync(pUsuario);
        }
        public async Task<int> EliminarAsync(Usuario pUsuario)
        {
            return await UsuarioDAL.EliminarAsync(pUsuario);
        }
        public async Task<Usuario> ObtenerPorIdAsync(Usuario pUsuario)
        {
            return await UsuarioDAL.ObtenerPorIdAsync(pUsuario);
        }
        public async Task<List<Usuario>> ObtenerTodosAsync()
        {
            return await UsuarioDAL.ObtenerTodosAsync();
        }
        public async Task<List<Usuario>> BuscarAsync(Usuario pUsuario)
        {
            return await UsuarioDAL.BuscarAsync(pUsuario);
        }
        public async Task<Usuario> EmailAsync(Usuario pUsuario)
        {
            return await UsuarioDAL.EmailAsync(pUsuario);
        }
        public async Task<List<Usuario>> BuscarIncluirRolesAsync(Usuario pUsuario)
        {
            return await UsuarioDAL.BuscarIncluirRolesAsync(pUsuario);
        }

    }
}
