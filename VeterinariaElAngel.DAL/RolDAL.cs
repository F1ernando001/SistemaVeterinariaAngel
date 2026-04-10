using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinariaElAngel.EN;

public static class RolDAL
{
    // 🔹 Guardar
    public static async Task<int> GuardarAsync(Rol pRol)
    {
        int result = 0;
        try
        {
            using (var dbContexto = new DBContexto())
            {
                dbContexto.Rol.Add(pRol);
                result = await dbContexto.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            result = 0;
            throw new Exception(ex.Message);
        }
        return result;
    }

    // 🔹 Modificar
    public static async Task<int> ModificarAsync(Rol pRol)
    {
        int result = 0;
        try
        {
            using (var dbContexto = new DBContexto())
            {
                var rol = await dbContexto.Rol
                    .FirstOrDefaultAsync(r => r.IdRol == pRol.IdRol);

                if (rol != null)
                {
                    rol.Nombre = pRol.Nombre;
                    rol.Descripcion = pRol.Descripcion;
                    rol.Estado = pRol.Estado;

                    dbContexto.Rol.Update(rol);
                    result = await dbContexto.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("El rol no existe");
                }
            }
        }
        catch (Exception ex)
        {
            result = 0;
            throw new Exception(ex.Message);
        }
        return result;
    }

    // 🔹 Eliminar
    public static async Task<int> EliminarAsync(int idRol)
    {
        int result = 0;
        try
        {
            using (var dbContexto = new DBContexto())
            {
                var rol = await dbContexto.Rol
                    .FirstOrDefaultAsync(r => r.IdRol == idRol);

                if (rol != null)
                {
                    dbContexto.Rol.Remove(rol);
                    result = await dbContexto.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("El rol no existe");
                }
            }
        }
        catch (Exception ex)
        {
            result = 0;
            throw new Exception(ex.Message);
        }
        return result;
    }

    // 🔹 Obtener por ID
    public static async Task<Rol> ObtenerPorIdAsync(int idRol)
    {
        try
        {
            using (var dbContexto = new DBContexto())
            {
                return await dbContexto.Rol
                    .FirstOrDefaultAsync(r => r.IdRol == idRol);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    // 🔹 Listar todos
    public static async Task<List<Rol>> ObtenerTodosAsync()
    {
        try
        {
            using (var dbContexto = new DBContexto())
            {
                return await dbContexto.Rol.ToListAsync();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
